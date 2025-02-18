using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
public class Save : MonoBehaviour {
    string path;
    
    void Start()
    {
        path = Path.GetFullPath("./" + "/Save");
    }

    void ParseToJson()
    {
        string json = "";

        foreach (IMine mt in GetComponentsInChildren<>())
        {

        }
    }

    void ParseFromJson()
    {

    }

    void SaveFile(string fileName, string information)
    {
        StreamWriter st = new StreamWriter(path + "/" + fileName);
        st.Write(information);
        st.Close();
    }

    string LoadFile(string fileName)
    {
        StreamReader sr = new StreamReader(path + "/" + fileName);
        string data = sr.ReadLine();
        return data;
    }

    [Serializable]
    public class Saver
    {
        public List<Material> materials;
    }

    public static class JsonHelper {
        public static string ToJson<T>(T[] array) {
            List<T> wrapper = new List<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }


        public static T[] FromJson<T>(string json) {
            List<T> wrapper = JsonUtility.FromJson<List<T>>(json);
            return wrapper.Items;
        }


        [Serializable]
        private class List<T> {
            public T[] Items;
        }
    }
}