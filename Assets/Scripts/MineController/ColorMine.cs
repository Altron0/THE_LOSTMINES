using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Color : MonoBehaviour
{
    [SerializeField] Material gold;
    [SerializeField] Material silver;
    [SerializeField] Material copper;
    [SerializeField] Material iron;

    static System.Random random = new System.Random();
    void Start()
    {
        colorMine();
    }

    void colorMine()
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
}
