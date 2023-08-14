using CarterGames.Assets.SaveManager;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu(fileName = "GeneralSaveObject")]
    public class GeneralSaveObject : SaveObject
    {
        public SaveValue<int> levelCount = new SaveValue<int>("LevelCount");
    }
}