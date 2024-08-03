using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    #region SaveSettings
    public static void SaveSettings(Settings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Settings.set";
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingData data = new SettingData(settings);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SettingData LoadSettings()
    {
        string path = Application.persistentDataPath + "/Settings.set";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingData data = formatter.Deserialize(stream) as SettingData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }

    }

    #endregion

    #region SaveGameManajer
    public static void SaveManaGer(Save save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Manager.man";
        FileStream stream = new FileStream(path, FileMode.Create);

        ManagerData data = new ManagerData(save);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ManagerData LoadManager()
    {
        string path = Application.persistentDataPath + "/Manager.man";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ManagerData data = formatter.Deserialize(stream) as ManagerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }

    }

    #endregion


    #region SaveUpgrade

    #endregion


}
