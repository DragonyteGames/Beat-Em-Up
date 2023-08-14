using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;

public class AssignCustomisation : MonoBehaviour
{   
    [Header("Player Hairstyle")]
    public SpriteRenderer hairstyle;

    [Header("Hair Options")]
    public List<Sprite> options = new List<Sprite>();

    private Color colorValue;
    void Start()
    {
        hairstyle.sprite = options[SaveDirector.me.currentOption];
        if( ColorUtility.TryParseHtmlString(SaveDirector.me.currentColor, out colorValue))
        {
            hairstyle.color = colorValue;
        }
    }
}
