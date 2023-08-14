using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public GameObject loadingScreen;
	public Slider loadingBar;
	public TextMeshProUGUI percentage;
	public GameObject[] uiElements;

    //function to load the desired scene
    public void LoadLevelMenu(int sceneIndex)
	{
		SoundMaster.me.SwitchTracks();
		StartCoroutine(MenuRun(sceneIndex));
    }

    public void LoadMainMenu(int sceneIndex)
	{
		SoundMaster.me.BackToMenu();
		StartCoroutine(MenuRun(sceneIndex));				
    }

    //start LoadAsync coroutine, return scene int index
    public void loadLevel (int sceneIndex)
	{
		SoundMaster.me.SwitchTracksLevel();
		StartCoroutine(LevelRun(sceneIndex));
	}

	//Load the character menu
    public void LoadCharMenu(int sceneIndex)
	{
		//SoundMaster.me.BackToMenu();
		StartCoroutine(MenuRun(sceneIndex));	
    }

	//Quit the application
	public void AppQuit()
	{
		StartCoroutine("AppQuitRun");
	}

	//load the level after playing sound
	public void OptionsMenu (string buttonName)
	{
		StartCoroutine(OptionRun(buttonName));
	}

/*----------------------------- IEnumerators--------------------------*/
// loading screen - load % progress on completing loading of next scene
		IEnumerator LoadAsync(int sceneIndex)
	{
		loadingScreen.SetActive (true);
		string levelName = "Level " + sceneIndex;
		AsyncOperation operation = SceneManager.LoadSceneAsync (levelName);

		while(!operation.isDone){

			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
				
			loadingBar.value = progress;
			percentage.text = progress * 100f + "%";
			yield return null;
		}
	}

	IEnumerator LoadAsyncMenu(int sceneIndex)
	{
		loadingScreen.SetActive (true);
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		while(!operation.isDone){

			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
				
			loadingBar.value = progress;
			percentage.text = progress * 100f + "%";
			yield return null;
		}
	}

	//coroutine for running Menu - Main Menu and Level Menu
	IEnumerator MenuRun(int sceneIndex)
	{
		yield return new WaitForSeconds(0.5f);
		StartCoroutine(LoadAsyncMenu(sceneIndex));
	}

	//coroutine for running Level based on "Level" + SceneIndex to get the name of the unity scene
	IEnumerator LevelRun(int sceneIndex)
	{
		yield return new WaitForSeconds(0.5f);
		StartCoroutine(LoadAsync(sceneIndex));
	}

	//coroutine for quitting the game
	IEnumerator AppQuitRun()
	{ 
		yield return new WaitForSeconds(0.5f);
		Application.Quit();	
	}

	//coroutine for opening the options menu window within the Main Menu
	IEnumerator OptionRun(string buttonName)
	{
		yield return new WaitForSeconds(0.5f);
		if(buttonName == "Options")
		{
			uiElements[0].SetActive(true);	
		}else if(buttonName == "ExitOptions")
		{
			uiElements[0].SetActive(false);	
		}
	}
}
