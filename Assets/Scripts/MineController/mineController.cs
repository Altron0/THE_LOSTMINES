using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class mineController : MonoBehaviour, ISavable
{
    //сохранение цвета шахт 
    string path;
    string file = "mineColor.json";
    List<int> mineColor = new List<int>();

    public int[] mineId = new int[12];

    static System.Random random = new System.Random();
    [SerializeField] Material[] materials =  new Material[4];


    void Start()
    {
        path = Path.GetFullPath("./") + @"Save";
        if(!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
        assigmentMine();
    }


    void assigmentMine()
    {
        int counter = 0;
        foreach (IsMine mine in GetComponentsInChildren<IsMine>())
        {
            List<Material> mt = new List<Material>();

            mine.TryGetComponent(out MeshRenderer renderer);
            int colorMineRandom = random.Next(0, 3);

            for(int i = 0;i < renderer.materials.Length;i++)
            {
                mt.Add(materials[colorMineRandom]);
            }
            mineId[counter] = colorMineRandom;
            counter++;
            mine.id = colorMineRandom;
            renderer.SetMaterials(mt);
            mineColor.Add(colorMineRandom);
        }
    }


    void regenirationMine(List<int> json)
    {
        int counter = 0;
        foreach (IsMine mine in GetComponentsInChildren<IsMine>())
        {
            mine.TryGetComponent(out MeshRenderer renderer);

            int mineColor = json[counter];
                
            List<Material> materialsMineColor = new List<Material>();

            for(int j = 0;j < renderer.materials.Length;j++)
            {
                materialsMineColor.Add(materials[mineColor]);
            }
            renderer.SetMaterials(materialsMineColor);
            counter++;
        }
    }


    public void Save()
    {
        Debug.Log("Mine saver");
    
        StreamWriter sw = new StreamWriter(path + "/" + file);

        string json = JsonHelper.ParseToJson(mineColor);
        Debug.Log(json);

        sw.Write(json);
        sw.Close();
    }


    [Serializable]
    public static class JsonHelper
    {
    public static string ParseToJson(List<int> mineColor)
        {
            Wrapper<int> wrapper = new Wrapper<int>();
            wrapper.array = mineColor.ToArray();

            string json = JsonUtility.ToJson(wrapper);

            return json;
        }

        public static List<int> ParseFromJson(string data)
        {
            Wrapper<int> wrapper = JsonUtility.FromJson<Wrapper<int>>(data);
            List<int> mineColor = (wrapper.array).ToList();
            return mineColor;
        }

        public class Wrapper<T>
        {
            public T[] array;
        }
    }

    public void Load()
    {
        Debug.Log("Mine Load");

        StreamReader sr = new StreamReader(path + "/" + file);
        string data = sr.ReadLine();

        List<int> json = JsonHelper.ParseFromJson(data);
        
        regenirationMine(json);

        sr.Close();
    }


    //     public void Save(string fileName, string data)
    //    {
    //     StreamWriter sw = new StreamWriter(path + "/" + fileName);
    //     sw.Write(data);
    //     sw.Close();
    //    }

    //    public string Load(string fileName)
    //    {
    //     StreamReader sr = new StreamReader(path + "/" + fileName);
    //     string data = sr.ReadLine();

    //     return data;
    //    }
}