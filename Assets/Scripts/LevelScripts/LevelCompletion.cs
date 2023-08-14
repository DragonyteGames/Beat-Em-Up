using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{   
    public ButtonScript menuHandler;

    void Start()
    {
        menuHandler = GameObject.Find("MenuHandler").GetComponent<ButtonScript>();
    }

    void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (hitBox.gameObject.tag == "Player")
        {
            menuHandler.LoadLevelMenu(1);
        }
    }
}
