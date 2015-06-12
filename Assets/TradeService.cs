using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Reflection;
using AUtils;

public class TradeService : MonoBehaviour {

	Dictionary<string, int> WoodBuyOrders = new Dictionary<string, int>();
	Dictionary<string, int> WoodSellOrders = new Dictionary<string, int>();
	Dictionary<string, int> ClayBuyOrders = new Dictionary<string, int>();
	Dictionary<string, int> ClaySellOrders = new Dictionary<string, int>();

	//TODO: this sometimes throws duplicates - why?
	public void RegisterOrder (string traderName, string resource, int amount)
	{
		bool orderExistsAlready = false;
		string transactionType = (amount > 0) ? "buy" : "sell";
		Dictionary<string, int> dict = GetOrderDictionary (resource, transactionType);
		
		foreach(KeyValuePair<string, int> order in dict)
		{
			if (order.Key == traderName && order.Value == amount) orderExistsAlready = true;
		}
		
		if (orderExistsAlready == false) dict.Add(traderName, amount);
	}

	void Update () 
	{
		SetOrderText("wood", "buy");
		SetOrderText("wood", "sell");
		SetOrderText("clay", "buy");
		SetOrderText("clay", "sell");
	}
	
	void SetOrderText (string resource, string transactionType)
	{
		string gameObjectName = string.Concat(Utilities.Capitalize(resource), Utilities.Capitalize(transactionType), "Orders");
		Text text = GameObject.Find(gameObjectName).GetComponent<Text>();
		text.text = string.Concat (Utilities.Capitalize(resource), " ", Utilities.Capitalize(transactionType)," Orders: \n");

		Dictionary<string, int> dict = GetOrderDictionary (resource, transactionType);
		foreach (KeyValuePair<string, int> order in dict)
		{
			text.text = string.Concat(text.text, order.Key, ": ", order.Value, "\n"); 
		}
	}

	Dictionary<string, int> GetOrderDictionary (string resource, string transactionType) 
	{
		string dictionaryName = string.Concat(Utilities.Capitalize(resource), Utilities.Capitalize(transactionType), "Orders");
		Dictionary<string, int> dict = this.GetType().GetField(dictionaryName, BindingFlags.Instance|BindingFlags.NonPublic).GetValue(this) as Dictionary<string, int>;
		return dict;
	}
}
