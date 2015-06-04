using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TradeService : MonoBehaviour {

	Dictionary<string, int> WoodBuyOrders = new Dictionary<string, int>();
	Dictionary<string, int> WoodSellOrders = new Dictionary<string, int>();
	Dictionary<string, int> ClayBuyOrders = new Dictionary<string, int>();
	Dictionary<string, int> ClaySellOrders = new Dictionary<string, int>();

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void RegisterOrder (string traderName, string resource, int amount)
	{

		// TODO: Do not add orders that have already been registered.

		if (resource == "wood" && amount > 0)
		{
			WoodBuyOrders.Add(traderName, amount);
		}
		else if (resource == "wood" && amount < 0)
		{
			WoodSellOrders.Add(traderName, amount);
		}
		else if (resource == "clay" && amount > 0)
		{
			ClayBuyOrders.Add(traderName, amount);
		}
		else if (resource == "clay" && amount > 0)
		{
			ClaySellOrders.Add(traderName, amount);
		}
		else
		{
			Debug.LogError("incorrect transaction");
		}
	}
}
