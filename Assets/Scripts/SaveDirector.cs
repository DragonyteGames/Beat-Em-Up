using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.SaveManager;

namespace Save
{
    public class SaveDirector : MonoBehaviour
    {
        private PlayerStatsSaveObject playerSaveObject;
        private GeneralSaveObject generalSaveObject;

        public static SaveDirector me;

        [Header("PlayerStats")] 
        // Start is called before the first frame update
        [SerializeField] public float health, maxHealth;
        [SerializeField] public int damageMin, damageMax;

        [Header("Level Index")] 
        [SerializeField] public int levelCount;

        [Header("Character costumzation Index")] 
        [SerializeField] public int currentHairOption;
        [SerializeField] public int currentEyesOption;
        [SerializeField] public string currentColor;
        
        void Awake()
        {
            me = GetComponent<SaveDirector>();
            playerSaveObject = SaveManager.GetSaveObject<PlayerStatsSaveObject>();
            generalSaveObject = SaveManager.GetSaveObject<GeneralSaveObject>();
            health = playerSaveObject.playerHealth.Value;
            maxHealth = playerSaveObject.playerMaxHealth.Value;
            damageMin = playerSaveObject.playerMinDamage.Value;
            damageMax = playerSaveObject.playerMaxDamage.Value;
            levelCount = generalSaveObject.levelCount.Value;
            currentHairOption = playerSaveObject.playerHairIndex.Value;
            currentEyesOption = playerSaveObject.playerEyesIndex.Value;
            currentColor = playerSaveObject.playerHairColor.Value;
        }
    }
}
