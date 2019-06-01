using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveProgress(IDictionary<string, int> data){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/1.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        // formatter.Serialize(stream, data);
        // stream.Close();
        // IDictionary<string, int> dataToSave = data;


        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(data.Count);
        foreach (var obj in data)
        {
            writer.Write(obj.Key);
            writer.Write(obj.Value);
        }
        writer.Flush();
        stream.Close();
    }

    public static bool LoadProgress(){
        string path = Application.persistentDataPath + "/1.sav";
        // if (File.Exists(path)){
        //     BinaryFormatter formatter = new BinaryFormatter();
        //     FileStream stream = new FileStream(path, FileMode.Open);
        //     stream.Close();
        //     IDictionary<string, int> data = formatter.Deserialize(stream) as IDictionary<string, int>;
        //     Progress.Instance.dict = data;

        // }
        if (File.Exists(path)){
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(stream);
            int count = reader.ReadInt32();
            var dictionary = new Dictionary<string, int>(count);
            for (int n = 0; n < count; n++)
            {
                var key = reader.ReadString().ToString();
                var value = reader.ReadInt32();
                dictionary.Add(key, value);
            }
            Progress.Instance.dict = dictionary;
            stream.Close();
            return true;
        }
        return false;
    }
}
