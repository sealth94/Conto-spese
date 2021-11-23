using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad{

    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/Expenses.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataController data = new DataController();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataController LoadData()
    {
        string path = Application.persistentDataPath + "/Expenses.sav";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataController data = formatter.Deserialize(stream) as DataController;

            stream.Close();
            return data;
        }

        else
        {
            Debug.LogError("Save not found in: " + path);
            return null;
        }

    }

    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/Expenses.sav";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        else
        {
            Debug.LogError("Save not found in: " + path);
        }
    }
}
