using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardParent> _startingHand;
    [SerializeField] private List<CardParent> _startingDrawPile;

    private List<CardParent> _discardPile;
    private List<CardParent> _drawPile;
    private List<CardParent> _cardsInHand;

    private void Awake()
    {
        _cardsInHand = _startingHand;
        _drawPile = _startingDrawPile;
    }

    //Add x cards on top of a draw pile to players hand
    private void DrawCards(int drawAmount)
    {
        for (int i = 0; i < drawAmount; i++)
        {
            _cardsInHand.Add(_discardPile[i]);
            _drawPile.RemoveAt(i);
        }
    }

    //Discard all cards in hand to the discard pile in order
    private void DiscardHand()
    {
        for (int i = 0; i < _cardsInHand.Count; i++)
        {
            _discardPile.Add(_cardsInHand[i]);
        }
    }

    //Randomly shuffles the discard pile into the draw pile
    private void DiscardToDrawPile()
    {
        for (int i = 0; i < _discardPile.Count; i++)
        {
            var index = Random.Range(0, _discardPile.Count);
            _drawPile.Add(_discardPile[index]);
        }
    }
}
