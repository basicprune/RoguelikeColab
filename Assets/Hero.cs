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
	public Transform lookReset;
	private EnemyHealth enemyHealthScript;
	public GameObject Gun;
	private Collider myCollider;

	public int Damage;

	public colliderCheck myColliderCheckScript;


	private Transform EnemyTransform;

	public GameObject EnemyObject;

	public GameObject enemyPOS;
	public float enemyhitPOS;

	public float Radius;

	private bool enterCheck = true;

	public float shootDelay;
	public float timer;
     void Start()
	 {
		myCollider = gameObject.GetComponent<Collider>();
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

			if (timer > shootDelay)
			{
				enemyHealthScript = enemyPOS.gameObject.GetComponent<EnemyHealth>(); 
				enemyHealthScript.Health -= Damage;
				timer = 0;
			}
			if (timer < shootDelay && enemyPOS == null)
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
		timer += Time.deltaTime;
		
		
		FaceEnemy();
	}
}
