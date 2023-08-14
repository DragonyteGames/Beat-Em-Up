using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;
using CarterGames.Assets.SaveManager;

public class CharacterChanger : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPart;

    [Header("Sprites to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();
    public List<Image> buttons = new List<Image>();

    [SerializeField] private int currentOption;
    [SerializeField] private string currentColor;
    
    public Color colorValue;
    private PlayerStatsSaveObject playerSaveObject;

    void Awake()
    {
        playerSaveObject = SaveManager.GetSaveObject<PlayerStatsSaveObject>("34b2e6c1-da2b-43e0-9a27-86e6a3248c18");
    }

    void Start()
    {   
        currentOption = SaveDirector.me.currentOption;
        currentColor = SaveDirector.me.currentColor;
        bodyPart.sprite = options[currentOption];
        if( ColorUtility.TryParseHtmlString(currentColor, out colorValue))
        {
            bodyPart.color = colorValue;
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


    public void GetColor(string colorIndex)
    {
        if(ColorUtility.TryParseHtmlString("#"+colorIndex, out colorValue))
        {
            currentColor = "#"+colorIndex;
            bodyPart.color = colorValue;
        }
    }

    public void Confirm()
    {
        playerSaveObject.playerHairIndex.Value = currentOption;
        playerSaveObject.playerHairColor.Value = currentColor;
    }
}
