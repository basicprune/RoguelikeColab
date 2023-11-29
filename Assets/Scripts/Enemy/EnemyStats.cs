using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public Spawner spawner;
	public int strength;
	public int health;

	public float CurrencyPerKill;
	public Currency currencyScript;
	void Start()
	{
		spawner = GetComponentInParent<Spawner>();
		currencyScript = GetComponentInParent<Currency>();
	}
	void Update()
	{
		if (health <= 0)
		{
			currencyScript.playerCurrency += CurrencyPerKill;
			spawner.enemies.Remove(gameObject);
			Destroy(gameObject);
		}
	}
}
