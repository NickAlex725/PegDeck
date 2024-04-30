using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardParent> _startingDrawPile;
    [SerializeField] private List<Transform> _cardPositions;
    [SerializeField] private Transform _drawPilePosition;
    [SerializeField] private Transform _discardPilePosition;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _drawPileCountUI;
    [SerializeField] private TextMeshProUGUI _discardPileCountUI;
    public TextMeshProUGUI discardText;
    public TextMeshProUGUI enemyAttackUI;

    public bool playerTurnOver = false;
    public bool discardMode = false;

    private List<CardParent> _discardPile;
    private List<CardParent> _drawPile;
    private List<CardParent> _cardsInHand;

    private InputBroadcaster _input;
    private Player _player;
    private Vector2 _discardCardPos;

    private void Awake()
    {
        _input = FindObjectOfType<InputBroadcaster>();
        _player = FindObjectOfType<Player>();
        _cardsInHand = new List<CardParent>();
        _discardPile = new List<CardParent>();
        _drawPile = new List<CardParent>(_startingDrawPile);

        _drawPileCountUI.text = _drawPile.Count.ToString();
    }

    #region input
    private void OnEnable()
    {
        _input.OnTouchPosition += CheckForCardTap;
    }

    private void OnDisable()
    {
        _input.OnTouchPosition -= CheckForCardTap;
    }

    public void CheckForCardTap(Vector2 touchPosition)
    {
        //get tap position
        Vector3 pos = Camera.main.ScreenToWorldPoint(touchPosition);
        pos.z = 0;
        //raycast and check if a card was tapped
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider != null)
        {
            CardParent card = hit.collider.GetComponent<CardParent>();
            if (card != null)
            {
                //card was hit
                if (discardMode)
                {
                    discardMode = false;
                    _discardCardPos = card.transform.position;
                    DiscardCard(card);
                    DrawCards(1);
                    discardText.gameObject.SetActive(false);
                    return;
                }
                card.CardAction();
            }
        }
    }
    #endregion
    //Add x cards on top of a draw pile to players hand
    public void DrawCards(int drawAmount)
    {
        for (int i = 0; i < drawAmount; i++)
        {
            if (_drawPile.Count == 0)
            {
                DiscardPileToDrawPile();
            }
            _cardsInHand.Add(_drawPile[0]);
            _drawPile.RemoveAt(0);
        }
        if (drawAmount > 1)
        {
            for (int i = 0; i < _cardsInHand.Count; i++)
            {
                _cardsInHand[i] = Instantiate(_cardsInHand[i], _drawPilePosition.position, Quaternion.identity);
                _cardsInHand[i].MoveTowardsPosition(_cardPositions[i].position);
            }
        }
        else if (drawAmount == 1)
        {
            var index = _cardsInHand.Count - 1;
            _cardsInHand[index] = Instantiate(_cardsInHand[index], _drawPilePosition.position, Quaternion.identity);
            _cardsInHand[index].MoveTowardsPosition(_discardCardPos);
        }

        //try setting active if inactive
        foreach (var card in _cardsInHand)
        {
            if(card.gameObject.activeInHierarchy == false) card.gameObject.SetActive(true);
        }

        //sfx
        AudioSFX.Instance.PlaySoundEffect(SFXType.DrawCard);

        UpdateUI();
    }

    //Discard all cards in hand to the discard pile in order
    public void DiscardHand()
    {
        var count = _cardsInHand.Count;

        for (int i = count - 1; i >= 0; i--)
        {
            _cardsInHand[i].MoveTowardsPosition(_discardPilePosition.position);
        }

        if(count > 0)
        {
            //sfx
            AudioSFX.Instance.PlaySoundEffect(SFXType.DiscardCard);
        }

        StartCoroutine(DelayEndPlayerTurn(count, 1.0f));
    }

    //Randomly shuffles the discard pile into the draw pile
    public void DiscardPileToDrawPile()
    {
        Debug.Log("DiscardPileToDrawPile()");

        var count = _discardPile.Count;
        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, _discardPile.Count);
            _drawPile.Add(_discardPile[index]);
            _discardPile.RemoveAt(index);
        }
        _discardPile.Clear();
        
        UpdateUI();
    }

    public void DiscardCard(CardParent card)
    {
        for (int i = 0; i < _cardsInHand.Count; i++)
        {
            CardParent tempCard = _cardsInHand[i];
            if(tempCard == card)
            {
                _discardPile.Add(tempCard);
                _cardsInHand.RemoveAt(i);

                tempCard.HideCard();
            }
        }


        UpdateUI();
    }

    private void UpdateUI()
    {
        _drawPileCountUI.text = _drawPile.Count.ToString();
        _discardPileCountUI.text = _discardPile.Count.ToString();
    }

    IEnumerator DelayEndPlayerTurn(int listCount, float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = listCount - 1; i >= 0; i--)
        {
            //_discardPile.Add(_cardsInHand[i]);
            DiscardCard(_cardsInHand[i]);
        }
        _cardsInHand.Clear();

        UpdateUI();

        playerTurnOver = true;
    }
}
