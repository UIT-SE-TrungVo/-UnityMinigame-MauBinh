using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represent a Hand of a Player, holding cards that can be used
/// </summary>
public class SyncObject
{
	//  Events ----------------------------------------

	//  Properties ------------------------------------

	//  Fields ----------------------------------------
	private bool _synced = false;

	//  Initialization --------------------------------


	//  Methods ---------------------------------------
	protected void RequestSync()
    {
		_synced = false;
    }

	public void ConfirmSync()
    {
		_synced = true;
    }

	public bool NeedSync()
	{
		return !_synced;
	}


	//  Event Handlers --------------------------------

}