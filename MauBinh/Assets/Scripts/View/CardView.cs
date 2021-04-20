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

	//  Fields ----------------------------------------
	private Card _card;


	//  Unity Methods ---------------------------------
	protected void Start()
	{
		
	}

	protected void Update()
	{
		this.GetComponent<SpriteRenderer>().sprite = CardImageLibrary.Instance.GetSprite(Card);
	}


	//  Methods ---------------------------------------


	//  Event Handlers --------------------------------
}
