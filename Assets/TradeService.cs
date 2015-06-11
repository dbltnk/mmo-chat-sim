using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Reflection;

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
		CreateOrderText("wood", "buy");
		CreateOrderText("wood", "sell");
		CreateOrderText("clay", "buy");
		CreateOrderText("clay", "sell");
	}

	void CreateOrderText (string resource, string transactionType)
	{
		string gameObjectName = string.Concat(Capitalize(resource), Capitalize(transactionType), "Orders");
		Text text = GameObject.Find(gameObjectName).GetComponent<Text>();
		text.text = string.Concat (Capitalize(resource)," Buy Orders: \n");

		string dictionaryName = string.Concat(Capitalize(resource), Capitalize(transactionType), "Orders");
		Dictionary<string, int> dict = this.GetType().GetField(dictionaryName, BindingFlags.Instance|BindingFlags.NonPublic).GetValue(this) as Dictionary<string, int>;

		foreach (KeyValuePair<string, int> order in dict)
		{
			text.text = string.Concat(text.text, order.Key, ": ", order.Value, "\n"); 
		}
	}

	string Capitalize(string sourceStr)
	{
		sourceStr.Trim();
		if (!string.IsNullOrEmpty(sourceStr))
		{
			char[] allCharacters = sourceStr.ToCharArray();
			
			for (int i = 0; i < allCharacters.Length; i++)
			{
				char character = allCharacters[i];
				if (i == 0)
				{
					if (char.IsLower(character))
					{
						allCharacters[i] = char.ToUpper(character);
					}
				}
			}
			return new string(allCharacters);
		}
		return sourceStr;
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
