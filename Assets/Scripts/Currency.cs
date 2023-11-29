using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
	public Text playerBalance;
	public float playerCurrency;
	void Update()
	{
		playerBalance.text = "$" + playerCurrency.ToString();
	}
}
