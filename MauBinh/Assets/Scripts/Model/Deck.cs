using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represent a pile of Cards which are not using by any players
/// </summary>
public class Deck
{
	//  Events ----------------------------------------


	//  Properties ------------------------------------
	public static Deck Instance
    {
		get
        {
			if (_instance == null) _instance = new Deck();
			return _instance;
        }
    }
	public HashSet<Card> CardPile { get => _cardPile; }
	public HashSet<Hand> AllPlayerHands { get => _playerHands; }


	//  Fields ----------------------------------------
	private static Deck _instance = null;
	private HashSet<Card> _cardPile = new HashSet<Card>();
	private HashSet<Hand> _playerHands = new HashSet<Hand>();


	//  Initialization --------------------------------
	public Deck()
	{
		Reset();
	}


	//  Methods ---------------------------------------
	public void Reset()
    {
		_cardPile.Clear();
		//Foreach pair (Pattern, Rank) --> Create the card
		foreach (Pattern pattern in (Pattern[])Enum.GetValues(typeof(Pattern)))
        {
			foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
			{
				AddACardToDeck(new Card(pattern, rank));
			}
		}
		Debug.Log("The Deck has " + _cardPile.Count + "card(s)");
	}

	private Card GetRandomCardInDeck()
	{
		if (_cardPile.Count <= 0) return null;

		//complicated random mechanic
		int r1 = (new System.Random().Next(0, _cardPile.Count));
		int r2 = (new System.Random().Next(0, _cardPile.Count));

		return _cardPile.ElementAt((r1 * r2)  % _cardPile.Count);
	}

	private void AddACardToDeck(Card card)
    {
		_cardPile.Add(card);
    }

	private void RemoveACardFromDeck(Card card)
    {
		_cardPile.Remove(card);
    }

	private void AddACardToPlayerHand(Hand hand, Card card)
	{
		if (_cardPile.Contains(card) && _playerHands.Contains(hand) && !hand.AllCards.Contains(card))
        {
			RemoveACardFromDeck(card);
			hand.AddACard(card);
        }
	}

	public void TakeCardFromPlayerHand(Hand hand, Card card)
	{
		if (_playerHands.Contains(hand) && hand.AllCards.Contains(card) && !_cardPile.Contains(card))
		{
			hand.RemoveACard(card);
			AddACardToDeck(card);
		}
	}

	public void AddHand(Hand hand)
    {
		if (!_playerHands.Contains(hand))
			_playerHands.Add(hand);
    }

	public void AddNumberOfCardsToPlayerHand(Hand hand, int numberOfCards)
    {
		for (int i = 0; i < Mathf.Min(numberOfCards, _cardPile.Count) ; i++)
        {
			AddACardToPlayerHand(hand, GetRandomCardInDeck());
        }
    }

	//  Event Handlers --------------------------------
}