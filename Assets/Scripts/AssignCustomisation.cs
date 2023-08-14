using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;

public class AssignCustomisation : MonoBehaviour
{   
    [Header("Player Hairstyle")]
    public SpriteRenderer bodyPart;

    [Header("Hair Options")]
    public List<Sprite> options = new List<Sprite>();

    private Color colorValue;
    void Start()
    {
        bodyPart.sprite = options[SaveDirector.me.currentOption];
        if( ColorUtility.TryParseHtmlString(SaveDirector.me.currentColor, out colorValue))
        {
            bodyPart.color = colorValue;
        }
    }
}
