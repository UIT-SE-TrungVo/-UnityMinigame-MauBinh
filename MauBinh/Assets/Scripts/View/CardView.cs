using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The view of the Card
/// </summary>
public class CardView : MonoBehaviour
{
	//  Events ----------------------------------------


	//  Properties ------------------------------------
	public Card Card { get => _card; set { _card = value; } }
	public Hand Hand { get => _hand; set { _hand = value; } }

	//  Fields ----------------------------------------
	private Card _card = null;
	private Hand _hand = null;

	[SerializeField] private Pattern _pattern;
	[SerializeField] private Rank _rank;

	private bool _loaded = false;

	//  Unity Methods ---------------------------------
	protected void Start()
	{
		Physics.queriesHitTriggers = true;
	}

	protected void Update()
	{
		//This only happens once --> no obsolete process
		if (_card != null && !_loaded)
		{
			this.GetComponent<SpriteRenderer>().sprite = CardImageLibrary.Instance.GetSprite(_card);
			_pattern = _card.Pattern;
			_rank = _card.Rank;
			_loaded = true;
			Debug.Log("Card " + _pattern + _rank + "loaded");
		}
	}

	//  Methods ---------------------------------------


	//  Event Handlers --------------------------------
	void OnMouseDown()
	{
		Debug.Log(this.Card + " Clicked");
		this.Hand.RemoveACard(this.Card);
		Destroy(this);
	}
}
