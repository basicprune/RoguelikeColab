using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Transform SpawnPOS;
	public GameObject Enemy;
	public int maxNumOfEnemies;

	public float spawnDelay = 2.5f;
	private float timer;

    void Update()
	 {
		timer += Time.deltaTime;
		if (timer > spawnDelay)
		{
			if (maxNumOfEnemies < 10)
			{
				maxNumOfEnemies++;
				Instantiate(Enemy, SpawnPOS.position, SpawnPOS.rotation);
				Enemy.active = true;
			}
			timer -= spawnDelay;
		}
		
		
	 }
}
