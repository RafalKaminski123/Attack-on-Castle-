using UnityEngine;

namespace SDA.Core
{
    public class SaveData
    {
        public int levelIndex;
        public int currency;

        public SaveData()
        {
            levelIndex = 1;
            currency = 1000;
        }
    }

    public class SaveSystem : MonoBehaviour
    {
        private SaveData save;

        public SaveData GetSave()
        {
            return save;
        }

        public void SaveData()
        {
            PlayerPrefs.SetString(Keys.SaveKeys.SAVE_KEY, JsonUtility.ToJson(save));
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey(Keys.SaveKeys.SAVE_KEY))
            {
                save = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(Keys.SaveKeys.SAVE_KEY));
            }
            else
            {
                save = new SaveData();
                SaveData();
            }
        }
    }
}
