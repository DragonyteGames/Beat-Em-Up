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
	
	void Start ()
	{
		if(me == null)
		{
			me = this;
			Object.DontDestroyOnLoad(gameObject);
			menuTrackTime = mySrc.time;
			mySrc.clip = tracks[0];
			mySrc.Play();
		}else
		{
			menuTrackTime = mySrc.time;
			mySrc.clip = tracks[0];
			mySrc.Play();
		}


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
		
		while(t < 1)
		{
			mySrc.volume = Mathf.Lerp(maxVolume, 0 , t);
			t += Time.deltaTime;
			yield return null;
		}
		
		mySrc.volume = t = 0;
		menuTrackTime = mySrc.time;
		mySrc.clip = tracks[1];
		mySrc.Play();
		
		while(t < 1)
		{
			mySrc.volume = Mathf.Lerp(0 , maxVolume, t);
			t += Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator SwitchTraxLevel()
	{
		t = 0;

		while(t < 1)
		{
			mySrc.volume = Mathf.Lerp(maxVolume, 0 , t);
			t += Time.deltaTime;
			yield return null;
		}

		mySrc.volume = t = 0;
		menuTrackTime = mySrc.time;
		mySrc.clip =  tracks[2]; //tracks[Random.Range(2, tracks.Length)];
		mySrc.Play();

		while(t < 1)
		{
			mySrc.volume = Mathf.Lerp(0 , maxVolume, t);
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
		
		while(t < 1)
		{
			mySrc.volume = Mathf.Lerp(maxVolume, 0 , t);
			t += Time.deltaTime;
			yield return null;
		}	
	}
	
	public void PlaySound(int num)
	{
		sfxSrc.PlayOneShot(sfx[num]);
	}
}
