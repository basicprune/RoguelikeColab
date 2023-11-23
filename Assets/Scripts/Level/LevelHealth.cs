using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHealth : MonoBehaviour
{
    public int levelHealth;
    public Text healthText;
    public Slider healthSlider;
   
	void Start()
    {
        healthSlider.maxValue = levelHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelHealth != 0)
        {
			healthSlider.value = levelHealth;
			healthText.text = healthSlider.value.ToString() + "/" + healthSlider.maxValue.ToString();
		}
       
    }
}
