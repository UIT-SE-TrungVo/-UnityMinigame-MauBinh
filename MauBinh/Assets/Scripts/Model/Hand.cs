using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represent a Hand of a Player, holding cards that can be used
/// </summary>
public class Hand : SyncObject
{
	//  Events ----------------------------------------


	//  Properties ------------------------------------
	public HashSet<Card> AllCards { get => _cards; }
	public int MaxHand { get => _maxHand; }


	//  Fields ----------------------------------------
	private HashSet<Card> _cards = new HashSet<Card>();
	private int _maxHand;


	//  Initialization --------------------------------
	public Hand(int maxHand)
    {
		_cards.Clear();
		Deck.Instance.AddHand(this);
		Deck.Instance.AddNumberOfCardsToPlayerHand(this, maxHand);
		_maxHand = maxHand;
		RequestSync();
    }

	//  Methods ---------------------------------------
	public void AddACard(Card card)
    {
		_cards.Add(card);
		RequestSync();
    }

	public void RemoveACard(Card card)
	{
		_cards.Remove(card);
		RequestSync();
	}


	//  Event Handlers --------------------------------

}
