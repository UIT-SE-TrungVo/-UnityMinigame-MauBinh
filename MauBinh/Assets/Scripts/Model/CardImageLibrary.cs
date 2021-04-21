using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS CARD IMAGE LIBRARY RETURN THE CORRECT IMAGE OF THE CARD by their PATTERN and RANK
/// </summary>
public class CardImageLibrary
{
    //  Event ----------------------------------------



    //  Const & Readonly ----------------------------------------
    private readonly string[] PATTERN = {"H", "D", "C", "S"};
    private readonly string[] RANK = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };


    //  Properties ------------------------------------
    public static CardImageLibrary Instance
    {
        get
        {
            if (_instance == null) _instance = new CardImageLibrary();
            return _instance;
        }
    }


	//  Fields ----------------------------------------
	private static CardImageLibrary _instance;


	//  Initialization --------------------------------


	//  Methods ---------------------------------------
    public Sprite GetSprite(Card card)
    {
        string filePath;
        if (card != null)
        {
            filePath = "Art/CardUp/" + RANK[(int)card.Rank] + PATTERN[(int)card.Pattern];
        }
        else filePath = "Art/Blank";

        Debug.Log(filePath);
        return Resources.Load<Sprite>(filePath);
    }


	//  Event Handlers --------------------------------

}