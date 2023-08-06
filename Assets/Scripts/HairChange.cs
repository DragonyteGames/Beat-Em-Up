using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairChange : MonoBehaviour
{

    public GameObject[] myHairstyles;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            myHairstyles[0].SetActive(true);
            myHairstyles[1].SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            myHairstyles[1].SetActive(true);
            myHairstyles[0].SetActive(false);
        }
    }
}
