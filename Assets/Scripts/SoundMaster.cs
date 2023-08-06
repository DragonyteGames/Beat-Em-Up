using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
	public AudioClip[] tracks;
	public AudioClip[] sfx;
	
	public AudioSource mySrc;
	public AudioSource sfxSrc;
	
	public float maxVolume;
	
	float menuTrackTime;
	float t;
	
	public static SoundMaster me;
	
	void Start () {
		
		me = GetComponent<SoundMaster>();
		Object.DontDestroyOnLoad(this);
	}
	
	void Update(){
		
		
		//if(Input.GetKeyDown(KeyCode.S)) StartCoroutine("SwitchTrax");
		
		//if(Input.GetKeyDown(KeyCode.D)) StartCoroutine("ReturnToMenu");
		
	}
	
	public void SwitchTracks()
	{
		
		StartCoroutine("SwitchTrax");
	}

	public void SwitchTracksLevel()
	{
		StartCoroutine("SwitchTraxLevel");
	}
	IEnumerator SwitchTrax()
	{
		
		t = 0;
		
		while(t < 1){
			GetComponent<AudioSource>().volume = Mathf.Lerp(maxVolume, 0 , t);
			t += Time.deltaTime;
			yield return null;
		}
		
		GetComponent<AudioSource>().volume = t = 0;
		menuTrackTime = mySrc.time;
		//print ("MenuTracktime = " + menuTrackTime);
		
		mySrc.clip = tracks[0];
		mySrc.Play();
		
		while(t < 1){
			GetComponent<AudioSource>().volume = Mathf.Lerp(0 , maxVolume, t);
			t += Time.deltaTime;
			yield return null;
		}
	}


	IEnumerator SwitchTraxLevel()
	{

		t = 0;

		while(t < 1){
			GetComponent<AudioSource>().volume = Mathf.Lerp(maxVolume, 0 , t);
			t += Time.deltaTime;
			yield return null;
		}

		GetComponent<AudioSource>().volume = t = 0;
		menuTrackTime = mySrc.time;
		//print ("MenuTracktime = " + menuTrackTime);

		mySrc.clip = tracks[Random.Range(1, tracks.Length)];
		mySrc.Play();

		while(t < 1){
			GetComponent<AudioSource>().volume = Mathf.Lerp(0 , maxVolume, t);
			t += Time.deltaTime;
			yield return null;
		}
	}
	
	
	public void BackToMenu()
	{
		
		StartCoroutine("ReturnToMenu");
	}
	
	public IEnumerator ReturnToMenu()
	{
		
		t = 0;
		
		while(t < 1){
			GetComponent<AudioSource>().volume = Mathf.Lerp(maxVolume, 0 , t);
			t += Time.deltaTime;
			yield return null;
		}
		GetComponent<AudioSource>().volume = t = 0;
		mySrc.clip = tracks[0];
		mySrc.time = menuTrackTime;
		mySrc.Play();
		
		while(t < 1){
			GetComponent<AudioSource>().volume = Mathf.Lerp(0 , maxVolume, t);
			t += Time.deltaTime;
			yield return null;
		}
		
	}
	
	
	
	public void PlaySound(int num)
	{
		
		sfxSrc.GetComponent<AudioSource>().PlayOneShot(sfx[num]);
		
	}
}
