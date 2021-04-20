using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represent a Hand of a Player, holding cards that can be used
/// </summary>
public class Hand
{
	//  Events ----------------------------------------


	//  Properties ------------------------------------
	public HashSet<Card> AllCards { get => _cards; }
	public int MaxHand { get => _maxHand; }


	//  Fields ----------------------------------------
	private HashSet<Card> _cards = new HashSet<Card>();
	private int _maxHand = 13;


	//  Initialization --------------------------------
	public Hand()
    {
		_cards.Clear();
		Deck.Instance.AddHand(this);
		Deck.Instance.AddNumberOfCardsToPlayerHand(this, 13);
    }

	//  Methods ---------------------------------------
	public void AddACard(Card card)
    {
		_cards.Add(card);
    }

	public void RemoveACard(Card card)
	{
		_cards.Remove(card);
	}


	//  Event Handlers --------------------------------

}
