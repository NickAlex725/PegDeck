using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardParent> _startingDrawPile;
    [SerializeField] private List<Transform> _cardPositions;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _drawPileCount;
    [SerializeField] private TextMeshProUGUI _discardPileCount;

    private List<CardParent> _discardPile;
    private List<CardParent> _drawPile;
    private List<CardParent> _cardsInHand;

    private void Awake()
    {
        _cardsInHand = new List<CardParent>();
        _discardPile = new List<CardParent>();

        _drawPile = _startingDrawPile;
        _drawPileCount.text = _drawPile.Count.ToString();
    }

    //Add x cards on top of a draw pile to players hand
    public void DrawCards(int drawAmount)
    {
        for (int i = 0; i < drawAmount; i++)
        {
            _cardsInHand.Add(_drawPile[0]);
            _drawPile.RemoveAt(0);
        }
        for (int i = 0; i < _cardsInHand.Count; i++)
        {
            Instantiate(_cardsInHand[i], _cardPositions[i].position, Quaternion.identity);
        }
        _drawPileCount.text = _drawPile.Count.ToString();
    }

    //Discard all cards in hand to the discard pile in order
    public void DiscardHand()
    {
        for (int i = 0; i < _cardsInHand.Count; i++)
        {
            _discardPile.Add(_cardsInHand[i]);
        }
        _cardsInHand.Clear();
        //need to destroy cards in hand
        _discardPileCount.text = _discardPile.Count.ToString();
    }

    //Randomly shuffles the discard pile into the draw pile
    public void DiscardPileToDrawPile()
    {
        for (int i = 0; i < _discardPile.Count; i++)
        {
            //BUG: will choose the same card multiple imtes, needs rework
            var index = Random.Range(0, _discardPile.Count);
            _drawPile.Add(_discardPile[index]);
        }
        _discardPile.Clear();
        _drawPileCount.text = _drawPile.Count.ToString();
        _discardPileCount.text = _discardPile.Count.ToString();
    }
}
