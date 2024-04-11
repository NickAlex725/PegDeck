using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardParent> _startingDrawPile;
    [SerializeField] private List<Transform> _cardPositions;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _drawPileCountUI;
    [SerializeField] private TextMeshProUGUI _discardPileCountUI;

    public bool playerTurnOver = false;

    private List<CardParent> _discardPile;
    private List<CardParent> _drawPile;
    private List<CardParent> _cardsInHand;

    private InputBroadcaster _input;

    private void Awake()
    {
        _input = FindObjectOfType<InputBroadcaster>();
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
                card.CardAction();
            }
        }
    }
    #endregion
    //Add x cards on top of a draw pile to players hand
    public void DrawCards(int drawAmount)
    {
        if(_drawPile.Count == 0)
        {
            DiscardPileToDrawPile();
        }

        for (int i = 0; i < drawAmount; i++)
        {
                _cardsInHand.Add(_drawPile[0]);
                _drawPile.RemoveAt(0);

        }
        for (int i = 0; i < _cardsInHand.Count; i++)
        {
            _cardsInHand[i] = Instantiate(_cardsInHand[i], _cardPositions[i].position, Quaternion.identity);
        }

        //try setting active if inactive
        foreach (var card in _cardsInHand)
        {
            if(card.gameObject.activeInHierarchy == false) card.gameObject.SetActive(true);
        }

        UpdateUI();
    }

    //Discard all cards in hand to the discard pile in order
    public void DiscardHand()
    {
        var count = _cardsInHand.Count;
        for (int i = count - 1; i >= 0; i--)
        {
            //_discardPile.Add(_cardsInHand[i]);
            DiscardCard(_cardsInHand[i]);
        }
        _cardsInHand.Clear();

        UpdateUI();

        playerTurnOver = true;
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
}
