using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{   
    [SerializeField] GameObject[] buttonImage;
    public GameObject lockImage;
	public void OnMouseDown()
    {   
        SoundMaster.me.PlaySound (6); 
        StartCoroutine("ButtonImageChange");
	}

	public void OnMouseEnter()
    { 
		transform.localScale = new Vector2 (1.1f, 1.1f);	
	}

    public void OnMouseExit()
    { 
		transform.localScale = new Vector2 (1f, 1f);
	}

    IEnumerator ButtonImageChange()
    {
        buttonImage[0].SetActive(false);
        buttonImage[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        buttonImage[0].SetActive(true);
        buttonImage[1].SetActive(false);
    }
}
