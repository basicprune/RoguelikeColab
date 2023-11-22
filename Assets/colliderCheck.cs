using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderCheck : MonoBehaviour
{
	public List<GameObject> enemyObjects = new List<GameObject>();
	public bool enemyHasLeftCollider;
	public bool enterCheck;

	public int random;

	public float Radius;
	private SphereCollider myColl;
	void Start()
	{
		myColl = gameObject.GetComponent<SphereCollider>();	
	}
	void Update()
	{
		myColl.radius = Radius;	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyObjects.Add(other.gameObject);
			enterCheck = true;
		}
		
		Debug.Log(other.gameObject.tag);
	}
	 void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			enemyObjects.Remove(other.gameObject);
			enemyHasLeftCollider = true;
			makeRandomInt();
		}
		if (enemyObjects.Count != 0)
		{
			enemyHasLeftCollider = false;
		}
	}
	public void makeRandomInt()
	{
		random = Random.Range(0, enemyObjects.Count);
	}
}
