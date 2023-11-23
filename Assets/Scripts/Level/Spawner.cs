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
	public int numOfEnemies;

	public float spawnDelay = 2.5f;
	private float timer;

	public bool allEnemiesSpawned;
	public List<GameObject> EnemyPrefabs = new List<GameObject>();
	public List<GameObject> enemies = new List<GameObject>();

	private GameObject enemySpawned;
	private int randomINT;
	public void randomEnemySelection()
	{
		
		randomINT = Random.RandomRange(0, EnemyPrefabs.Count);
	}

    void Update()
	 {
		randomEnemySelection();
		timer += Time.deltaTime;
			if (timer > spawnDelay)
			{
				if (numOfEnemies < maxNumOfEnemies)
				{
					numOfEnemies++;
				    enemySpawned = Instantiate(EnemyPrefabs[randomINT], SpawnPOS.position, SpawnPOS.rotation);
					Enemy.active = true;
				   
				    enemies.Add(enemySpawned.gameObject);
				}
				timer -= spawnDelay;
			}	
			foreach (GameObject enemy in enemies)
			{
				enemySpawned.transform.SetParent(SpawnPOS.transform);
			}
	 }
}
