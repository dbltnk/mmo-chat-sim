using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TradeService : MonoBehaviour {

	Dictionary<string, int> WoodBuyOrders = new Dictionary<string, int>();
	Dictionary<string, int> WoodSellOrders = new Dictionary<string, int>();
	Dictionary<string, int> ClayBuyOrders = new Dictionary<string, int>();
	Dictionary<string, int> ClaySellOrders = new Dictionary<string, int>();

	public GameObject WoodBuyOrdersObject;
	public GameObject WoodSellOrdersObject;
	public GameObject ClayBuyOrdersObject;
	public GameObject ClaySellOrdersObject;

	Text WoodBuyOrdersObjectText;
	Text WoodSellOrdersObjectText;
	Text ClayBuyOrdersObjectText;
	Text ClaySellOrdersObjectText;
	
	// Use this for initialization
	void Start () 
	{
		WoodBuyOrdersObjectText = WoodBuyOrdersObject.GetComponent<Text>();
		WoodSellOrdersObjectText = WoodSellOrdersObject.GetComponent<Text>();
		ClayBuyOrdersObjectText = ClayBuyOrdersObject.GetComponent<Text>();
		ClaySellOrdersObjectText = ClaySellOrdersObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		WoodBuyOrdersObjectText.text = "Wood Buy Orders: \n";
		foreach (KeyValuePair<string, int> order in WoodBuyOrders)
		{
			WoodBuyOrdersObjectText.text = string.Concat(WoodBuyOrdersObjectText.text, order.Key, ": ", order.Value, "\n"); 
		}

		WoodSellOrdersObjectText.text = "Wood Sell Orders: \n";
		foreach (KeyValuePair<string, int> order in WoodSellOrders)
		{
			WoodSellOrdersObjectText.text = string.Concat(WoodSellOrdersObjectText.text, order.Key, ": ", order.Value, "\n"); 
		}

		ClayBuyOrdersObjectText.text = "Clay Buy Orders: \n";
		foreach (KeyValuePair<string, int> order in ClayBuyOrders)
		{
			ClayBuyOrdersObjectText.text = string.Concat(ClayBuyOrdersObjectText.text, order.Key, ": ", order.Value, "\n"); 
		}

		ClaySellOrdersObjectText.text = "Clay Sell Orders: \n";
		foreach (KeyValuePair<string, int> order in ClaySellOrders)
		{
			ClaySellOrdersObjectText.text = string.Concat(ClaySellOrdersObjectText.text, order.Key, ": ", order.Value, "\n"); 
		}
	}

	public void RegisterOrder (string traderName, string resource, int amount)
	{

//		Debug.Log(traderName);
//		Debug.Log(resource);
//		Debug.Log(amount);
//		Debug.Log("-----------");


		if (resource == "wood" && amount > 0)
		{
			bool orderExistsAlready = false;
			foreach(KeyValuePair<string, int> order in WoodBuyOrders)
			{
				if (order.Key == traderName && order.Value == amount) orderExistsAlready = true;
			}
			if (orderExistsAlready == false) WoodBuyOrders.Add(traderName, amount);
		}
		else if (resource == "wood" && amount < 0)
		{
			bool orderExistsAlready = false;
			foreach(KeyValuePair<string, int> order in WoodSellOrders)
			{
				if (order.Key == traderName && order.Value == amount) orderExistsAlready = true;
			}
			if (orderExistsAlready == false) WoodSellOrders.Add(traderName, amount);
		}
		else if (resource == "clay" && amount > 0)
		{
			bool orderExistsAlready = false;
			foreach(KeyValuePair<string, int> order in ClayBuyOrders)
			{
				if (order.Key == traderName && order.Value == amount) orderExistsAlready = true;
			}
			if (orderExistsAlready == false) ClayBuyOrders.Add(traderName, amount);
		}
		else if (resource == "clay" && amount < 0)
		{
			bool orderExistsAlready = false;
			foreach(KeyValuePair<string, int> order in ClaySellOrders)
			{
				if (order.Key == traderName && order.Value == amount) orderExistsAlready = true;
			}
			if (orderExistsAlready == false) ClaySellOrders.Add(traderName, amount);
		}
		else
		{
			Debug.LogError("incorrect transaction");
		}
	}
}
