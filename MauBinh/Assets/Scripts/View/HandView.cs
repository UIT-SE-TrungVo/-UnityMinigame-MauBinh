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
	[SerializeField] private Hand _hand = new Hand(13);
	[SerializeField] private GameObject _cardPrefab;

	private const float CARD_SPACING = 0.5f;
	private float _cardWidth = 0;

	private List<GameObject> arrCardViews = new List<GameObject>();

	private HashSet<Card> _oldCards = new HashSet<Card>();

	//  Unity Methods ---------------------------------
	protected void Start()
	{
		_cardWidth = _cardPrefab.GetComponent<Renderer>().bounds.size.x;
	}

	protected void Update()
	{
		if (_hand.NeedSync())
        {
			Vector2 handPoint = GetHandStartPoint();
			foreach (GameObject obj in arrCardViews)
				Destroy(obj.gameObject);

			Vector3 stackEffect = Vector3.back / 100;
			foreach (Card card in _hand.AllCards)
			{
				GameObject newCard = Instantiate(_cardPrefab, handPoint, Quaternion.identity);
				newCard.GetComponent<CardView>().Card = card;
				newCard.GetComponent<CardView>().Hand = Hand;

				arrCardViews.Add(newCard);
				handPoint += Vector2.right * _cardWidth * (1 - CARD_SPACING);

				newCard.transform.Translate(stackEffect);
				stackEffect += Vector3.back / 100;
			}

			_hand.ConfirmSync();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			//Delete all card in hand
			foreach (GameObject obj in arrCardViews)
				Destroy(obj.gameObject);

			//Instantiate new hand
			Deck.Instance.Reset();
			Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
        }
	}


	//  Methods ---------------------------------------
	private Vector2 GetHandStartPoint()
    {
		Vector2 result = this.transform.position;
		int cardCount = _hand.AllCards.Count;
		if (cardCount == 0) return result;

		float handWidth = cardCount * _cardWidth - (cardCount - 1) * (_cardWidth * CARD_SPACING);
		result += Vector2.left * handWidth / 2 + Vector2.right * _cardWidth / 2;

		return result;
	}


    //  Event Handlers --------------------------------
   
}