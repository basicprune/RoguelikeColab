using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public Spawner spawner;
	public int strength;
	public int health;
	void Start()
	{
		spawner = GetComponentInParent<Spawner>();
	}
	void Update()
	{
		if (health <= 0)
		{
			spawner.enemies.Remove(gameObject);
			Destroy(gameObject);
		}
	}
}
