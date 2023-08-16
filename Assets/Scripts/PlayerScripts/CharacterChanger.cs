using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;
using CarterGames.Assets.SaveManager;
using TMPro;

public class CharacterChanger : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;

    [Header("Player body type")]
    public string bodyType;

    [Header("Sprites to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    [SerializeField] private int currentOption;
    [SerializeField] private string currentColor;
    [SerializeField] private string hexString;

    public Color colorValue;
    public FlexibleColorPicker colorPicker;
    public TMP_InputField hexText;
    private PlayerStatsSaveObject playerSaveObject;

    void Awake()
    {
        playerSaveObject = SaveManager.GetSaveObject<PlayerStatsSaveObject>("34b2e6c1-da2b-43e0-9a27-86e6a3248c18");
    }

    void Start()
    {  
        if(bodyType == "Hair")currentOption = SaveDirector.me.currentHairOption;
        if(bodyType == "Eyes") currentOption = SaveDirector.me.currentEyesOption; 

        currentColor = SaveDirector.me.currentColor;        
        hexString = hexText.text;
        bodyPart.sprite = options[currentOption];

        if (ColorUtility.TryParseHtmlString(currentColor, out colorValue))
        {
            colorPicker.SetColor(colorValue);
        }
        
    }

    void FixedUpdate()
    {
        hexString = hexText.text;
        if(bodyType == "Hair"){
            bodyPart.color = colorPicker.color;
        }
    }

    public void NextOptions()
    {
        currentOption++;

        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }

        bodyPart.sprite = options[currentOption];
    }

    public void PreviousOptions()
    {
        currentOption--;

        if(currentOption <= 0)
        {
            currentOption = options.Count -1;
        }

        bodyPart.sprite = options[currentOption];
    }

    public void Confirm()
    {
        if(bodyType == "Hair")playerSaveObject.playerHairIndex.Value = currentOption; 
        if(bodyType == "Eyes")playerSaveObject.playerEyesIndex.Value = currentOption;
        playerSaveObject.playerHairColor.Value = hexString;
    }
}
