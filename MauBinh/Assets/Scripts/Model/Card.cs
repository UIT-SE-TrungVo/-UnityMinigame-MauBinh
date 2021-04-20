using UnityEngine;

/// <summary>
/// Represent a playing card, contain Pattern and Rank
/// </summary>
public class Card
{
	//  Events ----------------------------------------


	//  Properties ------------------------------------
	public Pattern Pattern { get => _pattern; }
	public Rank Rank { get => _rank; }

	//  Fields ----------------------------------------
	[SerializeField] protected Pattern _pattern;
	[SerializeField] protected Rank _rank;

	//  Initialization --------------------------------
	public Card(Pattern pattern, Rank rank)
    {
		this._pattern = pattern;
		this._rank = rank;
    }

	//  Methods ---------------------------------------


	//  Event Handlers --------------------------------
}
