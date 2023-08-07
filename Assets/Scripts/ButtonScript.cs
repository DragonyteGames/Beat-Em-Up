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
    public void LoadLevelMenu(){
        loadLevel(1);
		SoundMaster.me.SwitchTracksLevel ();
    }

    //start LoadAsync coroutine, return scene int index
    public void loadLevel (int sceneIndex)
	{
		StartCoroutine (LoadAsync(sceneIndex));
	}

    // loading screen - load % progress on completing loading of next scene
	IEnumerator LoadAsync(int sceneIndex){

		loadingScreen.SetActive (true);
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		while(!operation.isDone){

			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
				
			loadingBar.value = progress;
			percentage.text = progress * 100f + "%";
			yield return null;
		}
	}

	public void OptionsMenu (string buttonName)
	{
		if(buttonName == "Options")
		{
			uiElements[0].SetActive(true);	
		}else if(buttonName == "ExitOptions")
		{
			uiElements[0].SetActive(false);	
		}
	}	
}
