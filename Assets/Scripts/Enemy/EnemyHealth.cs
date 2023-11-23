using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 150;
   

    // Update is called once per frame
    void Update()
    {  
            if (Health <= 0)
            {
				Destroy(gameObject);
			}
    }
}
