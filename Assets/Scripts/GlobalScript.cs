using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
	static public GameObject[] hitParticle;
    static public GameObject[] bloodParticle;

    void Awake()
    {
        hitParticle = GameObject.FindGameObjectsWithTag("FXHit");
        bloodParticle = GameObject.FindGameObjectsWithTag("FXBlood");
    }
}
