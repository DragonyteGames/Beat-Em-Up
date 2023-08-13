using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.SaveManager;

namespace Save
{
    public class SaveDirector : MonoBehaviour
    {
        private PlayerStatsSaveObject saveObject;
        public static SaveDirector me;

        [Header("PlayerStats")] 
        // Start is called before the first frame update
        [SerializeField] public float health, maxHealth;
        [SerializeField] public int damageMin, damageMax;
        
        
        void Awake()
        {
            me = GetComponent<SaveDirector>();
            Object.DontDestroyOnLoad(this);
            saveObject = SaveManager.GetSaveObject<PlayerStatsSaveObject>();   
        }

        void Start()
        {
            health = saveObject.playerHealth.Value;
            maxHealth = saveObject.playerMaxHealth.Value;
            damageMin = saveObject.playerMinDamage.Value;
            damageMax = saveObject.playerMaxDamage.Value;
        }
    }
}
