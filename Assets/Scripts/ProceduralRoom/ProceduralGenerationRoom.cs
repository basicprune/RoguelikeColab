using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationRoom : MonoBehaviour
{
    public List<GameObject> joinPoints = new List<GameObject>();
    public List<GameObject> exitPoints = new List<GameObject>();
    public List<GameObject> objectRoomObjects = new List<GameObject>();

    private Transform myExitTransform;
    private GameObject joinPoint;
    private GameObject exitPoint;
    private RoomObject myRoomObjectScript;


    public GameObject Exit;
    public GameObject Join;
    public int numOfRooms;
	// Start is called before the first frame update
	void Start()
    {
  //      foreach (GameObject roomObject in objectRoomObjects)
  //      {
		//	numOfRooms++;
		//	Debug.Log(numOfRooms);
		//	myRoomObjectScript  = roomObject.GetComponent<RoomObject>();
		//	//myRoomObjectScript.exitPoint.transform.position = myRoomObjectScript.joinPoint.transform.position;
  //          roomObject.transform.position = objectRoomObjects[numOfRooms].transform.position;
			
		//}

        Join.transform.position = Exit.transform.position; // chnage to use int value from a list determining which exit tansform to use // use the exit transform of the precious roomObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
