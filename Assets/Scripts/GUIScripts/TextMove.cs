using UnityEngine;
using System.Collections;
using TMPro;

public class TextMove : MonoBehaviour {

	float timer; //timer for duration of flying sword appearance
	public float speed; //speed of sword
	public float num; //value for timer
	public bool startRun;

	void Start()
	{
		StartCoroutine("MoveText");
	}

	IEnumerator MoveText () {
		timer = 0;
		startRun = true;
		yield return new WaitForEndOfFrame();
		while(timer < num  && startRun == true){
			
			timer += Time.deltaTime; 
			transform.Translate(new Vector2(0,speed*Time.deltaTime));

			yield return new WaitForEndOfFrame();
			

		}
		startRun = false;
	}

}
