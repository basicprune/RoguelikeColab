using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndColl : MonoBehaviour
{
	private EnemyStats enemyStatsScript;
	public LevelHealth health;
	public Spawner spawner;
	// Start is called before the first frame update


	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.gameObject.tag == "Enemy")
		{
			enemyStatsScript = other.gameObject.GetComponent<EnemyStats>();
			health.levelHealth -= enemyStatsScript.strength;
			Destroy(other.gameObject);
			spawner.enemies.Remove(other.gameObject);
		}
		// myEnemyStrengthScript = null;
	}
}
