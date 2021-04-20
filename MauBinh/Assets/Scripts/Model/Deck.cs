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
	private void Reset()
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
	}

	private Card GetRandomCardInDeck()
	{
		return _cardPile.ElementAt(new System.Random().Next(_cardPile.Count));
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
		if (_cardPile.Contains(card) && _playerHands.Contains(hand))
        {
			RemoveACardFromDeck(card);
			hand.AddACard(card);
        }
	}

	public void AddHand(Hand hand)
    {
		if (!_playerHands.Contains(hand))
			_playerHands.Add(hand);
    }

	public void AddNumberOfCardsToPlayerHand(Hand hand, int numberOfCards)
    {
		for (int i = 0; i < numberOfCards; i++)
        {
			AddACardToPlayerHand(hand, GetRandomCardInDeck());
        }
    }

	//  Event Handlers --------------------------------
}