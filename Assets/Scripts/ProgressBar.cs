using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform myParent;
    [SerializeField] private Transform target;
    
    public string myType;

    //update the health bar
    public void UpdateHealth(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void FixedUpdate()
    {   
        if(myType == "PlayerHealth")
        {
            myParent.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
        }

        if(myType == "EnemyHealth")
        {
            myParent.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
        }
        
    }
}
