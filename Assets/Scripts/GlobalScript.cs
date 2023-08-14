using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Save;
using CarterGames.Assets.SaveManager;

public class GlobalScript : MonoBehaviour
{
	static public GameObject[] hitParticle;
    static public GameObject[] bloodParticle;

    static public int killCount;
    static public bool playerDead;

    public int levelReq;
    public int level;
    public GameObject completionTarget;

    private bool triggerCompletion;
    private bool levelCompleted;
    private GeneralSaveObject generalSaveObject;

    void Awake()
    {
        hitParticle = GameObject.FindGameObjectsWithTag("FXHit");
        bloodParticle = GameObject.FindGameObjectsWithTag("FXBlood");
        generalSaveObject = SaveManager.GetSaveObject<GeneralSaveObject>("48669a80-7eaf-46b2-996c-c5cb2229a420");
    }
    
    void Start()
    {
        killCount = 0;
        triggerCompletion = false;
        playerDead = false;
        completionTarget.SetActive(false);
    }
    void FixedUpdate()
    {   
        if(killCount >= levelReq)
        {
            if(!triggerCompletion)
            {
                completionTarget.SetActive(true);
                generalSaveObject.levelCount.Value  = level + 1;
                triggerCompletion = true;
            }
        }
    }
}
