using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[System.Serializable]
public class UserSettings{

    public float volumeSFX;     
    public float volumeVoice;
    public float volumeBG;
    public float volumeMusic;

    public UserSettings()
    {
        volumeSFX = 100f;
        volumeVoice = 100f;
        volumeBG = 100f;
        volumeMusic = 100f;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/userSettings.dat", FileMode.Open);
        bf.Serialize(file, this);
        file.Close();
    }

    public static UserSettings Load()
    {
        if(File.Exists(Application.persistentDataPath + "/userSettings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userSettings.dat", FileMode.Open);
            UserSettings us =  (UserSettings)bf.Deserialize(file);
            file.Close();
            return us;
        }
        else // Usually due to it being the first time the game has been opened. If not, uh oh
        {
            Debug.Log("No previous data found");
            UserSettings us = new UserSettings();
            return us;
        }
        
    }

    public void ClearSave() // Only clear stuff like progress and unlocks
    {
        UserSettings us = new UserSettings();
        us.volumeSFX = GameMaster.Instance.userSettings.volumeSFX;
        us.volumeVoice = GameMaster.Instance.userSettings.volumeVoice;
        us.volumeBG = GameMaster.Instance.userSettings.volumeBG;
        us.volumeMusic = GameMaster.Instance.userSettings.volumeMusic;
        us.Save();
    }
}
