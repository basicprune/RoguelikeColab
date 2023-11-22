using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndColl : MonoBehaviour
{
	private EnemyStrength myEnemyStrengthScript;
	public LevelHealth health;
	// Start is called before the first frame update


	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.gameObject.tag == "Enemy")
		{
			myEnemyStrengthScript = other.gameObject.GetComponent<EnemyStrength>();
			health.levelHealth -= myEnemyStrengthScript.strength;
			Destroy(other.gameObject);
		}
		// myEnemyStrengthScript = null;
	}
}
