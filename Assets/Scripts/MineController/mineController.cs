using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class mineController : MonoBehaviour, ISavable
{
    string path;
    [SerializeField] Material gold;
    [SerializeField] Material silver;
    [SerializeField] Material copper;    
    [SerializeField] Material iron;

    static System.Random random = new System.Random();
    void Start()
    {
        path = Path.GetFullPath("./") + "Save";
        if(!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
        assigmentMine();
    }

    void assigmentMine()
    {
        Material[] materials = new Material[]{gold, silver, copper, iron};

        foreach (IsMine obj in GetComponentsInChildren<IsMine>())
        {
            List<Material> mt = new List<Material>();

            obj.TryGetComponent(out MeshRenderer renderer);
            int colorMineRandom = random.Next(0, 3);

            for(int i = 0;i < renderer.materials.Length;i++)
            {
                mt.Add(materials[colorMineRandom]);
            }
            renderer.SetMaterials(mt);
        }
    }

    public void Save()
    {
        Debug.Log("Mine save"); 
    }

    public void Load()
    {
        throw new NotImplementedException();
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

