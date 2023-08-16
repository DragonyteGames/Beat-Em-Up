using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;

public class AssignCustomisation : MonoBehaviour
{   
    [Header("Player Hairstyle")]
    public SpriteRenderer hairStyle;
    public SpriteRenderer eyeStyle;

    [Header("Hair Options")]
    public List<Sprite> hairOptions = new List<Sprite>();

    [Header("Eyes Options")]
    public List<Sprite> eyesOptions = new List<Sprite>();    

    private Color colorValue;
    private string hexString;

    void Start()
    {   
        hexString = SaveDirector.me.currentColor;
        hairStyle.sprite = hairOptions[SaveDirector.me.currentHairOption];
        eyeStyle.sprite = eyesOptions[SaveDirector.me.currentEyesOption];
        if(ColorUtility.TryParseHtmlString(hexString, out colorValue))
        {
            hairStyle.color = colorValue;
        }
    }
}
