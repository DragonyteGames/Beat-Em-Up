using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Save;
using CarterGames.Assets.SaveManager;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

	private GeneralSaveObject generalSaveObject;

    private void Start()
	{
		generalSaveObject = SaveManager.GetSaveObject<GeneralSaveObject>("48669a80-7eaf-46b2-996c-c5cb2229a420");
		int unlockedLevel = SaveDirector.me.levelCount;
		for(int i = 0; i < buttons.Length; i++)
		{
			buttons[i].interactable = false;
            buttons[i].gameObject.GetComponent<ButtonInteraction>().lockImage.SetActive(true);
		}
		for(int i = 0; i < unlockedLevel; i++)
		{
			buttons[i].interactable = true;
            buttons[i].gameObject.GetComponent<ButtonInteraction>().lockImage.SetActive(false);
		}
	}

}
