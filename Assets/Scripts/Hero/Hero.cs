using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using TreeEditor;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class Hero : MonoBehaviour
{
	[Header("Script References")]

	private EnemyStats enemyStatsScript;
	[InspectorName("Collider Check Script")] public colliderCheck myColliderCheckScript;

	[Header("Hero Settings")]

	[Tooltip("Damage Per Shot (DPS)")] public int Damage;
	[Tooltip("Radius, the area your hero can shoot within")] public float Radius;
	[Tooltip("Delay between Attacks")] public float attackDelay;

	[Tooltip("Enemy Prefab")] public GameObject EnemyObject;


	[HideInInspector] public GameObject enemyPOS;
	[HideInInspector] public float enemyhitPOS;
	private bool enterCheck = true;
	private float timer;
     void Start()
	 {
		
	 }
	public void FaceEnemy()
	{

		if (myColliderCheckScript.enemyObjects.Count > 0)
		{
			if (myColliderCheckScript.enterCheck == true && enterCheck == true)
			{
				enemyPOS = myColliderCheckScript.enemyObjects[0];
				enterCheck = false;
			} else
			{
				enemyPOS = myColliderCheckScript.enemyObjects[myColliderCheckScript.random];
			}
			Debug.Log(enemyPOS);

			if (timer > attackDelay)
			{
				enemyStatsScript = enemyPOS.gameObject.GetComponent<EnemyStats>();
				enemyStatsScript.health -= Damage;
				timer = 0;
			}
			if (timer < attackDelay && enemyPOS == null)
			{
				myColliderCheckScript.enemyObjects.Remove(enemyPOS); // if null then remove from list so there isn't any null enemyPOS
			}


		} else { enemyPOS = null;}
			
		if (enemyPOS != null) 
		{ 
			Debug.DrawLine(transform.position, enemyPOS.transform.position);
			Vector3 direction = gameObject.transform.up - enemyPOS.transform.position;
			var target = Quaternion.LookRotation(direction);
			transform.rotation = target;
		}

	}
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(gameObject.transform.position, Radius);
	}


	// Update is called once per frame
	void Update()
    {
		myColliderCheckScript.Radius = Radius;
		timer += Time.deltaTime;
		FaceEnemy();
	}
}
