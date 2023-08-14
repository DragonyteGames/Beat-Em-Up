using CarterGames.Assets.SaveManager;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu(fileName = "PlayerStatsSaveObject")]
    public class PlayerStatsSaveObject : SaveObject
    {
        public SaveValue<float> playerHealth = new SaveValue<float>("PlayerHealth");
        public SaveValue<float> playerMaxHealth = new SaveValue<float>("PlayerMaxHealth");
        public SaveValue<int> playerMinDamage = new SaveValue<int>("PlayerMinDamage");
        public SaveValue<int> playerMaxDamage = new SaveValue<int>("PlayerMaxDamage");
        public SaveValue<int> playerHairIndex = new SaveValue<int>("PlayerHairIndex");
        public SaveValue<string> playerHairColor = new SaveValue<string>("PlayerHairColor");
    }
}