using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StoreManager : MonoBehaviour
{
    public TMP_Text playerMoney;

    public GameObject noItemSelected;

    public GameObject itemSelected;
    public TMP_Text itemName;
    public Image itemImage;
    public TMP_Text itemDescription;
    public TMP_Text itemCost;
    public Color canAffordColour;
    public Color cannotAffordColour;


    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem m_eventSystem;

    void Start()
    {
        noItemSelected.SetActive(true);
        itemSelected.SetActive(false);
    }

    void Update()
    {
        CheckMouseOverStore();

    }

    private void CheckMouseOverStore()
    {
        PointerEventData m_PointerEventData;

        //new pointerEvent
        m_PointerEventData = new PointerEventData(m_eventSystem);
        //set pointer event to mouse pos
        m_PointerEventData.position = Input.mousePosition;

        //create result list
        List<RaycastResult> results = new List<RaycastResult>();

        //raycast w/ graphic raycaster and mouse click pos
        raycaster.Raycast(m_PointerEventData, results);

       
        if (results.Count > 0 ) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (results[0].gameObject.name != "Handle")
                {
                    SelectItem(/*results[0].gameObject.GetComponent<StoreItem>().GetItem()*/results[0].gameObject);
                }
            }
            
        }
    }

    private void SelectItem(/*Selected Item*/GameObject selectedObject)
    {
        noItemSelected.SetActive(false);
        itemSelected.SetActive(true);

        itemName.text = selectedObject.name;

        //get item image

        //get item description

        //get item cost and compare to players money inventory

        //change cost colour based on whether player can afford or not
    }
}
