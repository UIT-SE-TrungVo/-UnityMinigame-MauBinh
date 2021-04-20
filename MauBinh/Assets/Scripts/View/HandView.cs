using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
/// Illustrate the hand on the screen
/// </summary>
public class HandView : MonoBehaviour
{
	//  Events ----------------------------------------


	//  Properties ------------------------------------
	public Hand Hand { get => _hand; }


	//  Fields ----------------------------------------
	[SerializeField] private Hand _hand = new Hand();
	[SerializeField] private GameObject _cardPrefab;

	private const float CARD_SPACING = 0;
	private float _cardWidth = 0;

	private List<GameObject> arrCardViews = new List<GameObject>();

	//  Unity Methods ---------------------------------
	protected void Start()
	{
		_cardWidth = _cardPrefab.GetComponent<Renderer>().bounds.size.x;
	}

	protected void Update()
	{
		Vector2 handPoint = GetHandStartPoint();
		foreach (GameObject obj in arrCardViews)
			Destroy(obj.gameObject);

		foreach (Card card in _hand.AllCards)
		{
			_cardPrefab.GetComponent<CardView>().Card = card;
			arrCardViews.Add(Instantiate(_cardPrefab, handPoint, Quaternion.identity));
			handPoint += Vector2.right * _cardWidth * (1 - CARD_SPACING);
        }
	}


	//  Methods ---------------------------------------
	private Vector2 GetHandStartPoint()
    {
		Vector2 result = this.transform.position;
		int cardCount = _hand.AllCards.Count;
		if (cardCount == 0) return result;

		float handWidth = cardCount * _cardWidth - (cardCount - 1) * (_cardWidth * CARD_SPACING);
		result -= Vector2.left * handWidth / 2;

		return result;
	}


	//  Event Handlers --------------------------------
}