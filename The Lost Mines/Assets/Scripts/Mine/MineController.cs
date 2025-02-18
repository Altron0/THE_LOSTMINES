using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{

    [SerializeField] Material gold;
    [SerializeField] Material silver;
    [SerializeField] Material copper;
    [SerializeField] Material iron;


    System.Random random = new System.Random();

    void Start()
    {
        foreach (IMine mine in GetComponentsInChildren<IMine>()) {
            RandomizeMineType(mine);
        }
    }

    void RandomizeMineType(IMine mine)
    {
        mine.transform.TryGetComponent(out MeshRenderer renderer);

        int a = random.Next(0, 3);

        Material[] arr = new Material[4]{gold,silver,iron,copper};

        List<Material> list = new List<Material>();

        for(int i = 0;i < renderer.materials.Length;i++){
            list.Add(arr[a]);
        }

        renderer.SetMaterials(list);
    }
}
