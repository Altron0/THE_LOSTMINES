using System.Collections.Generic;
using UnityEngine;

public class IMine : MonoBehaviour
{
    MineTypes mineTypes;

    public Saver getMaterial()
    {
        Saver sv = new Saver();
        List<Material> material = new List<Material>();
        TryGetComponent(out MeshRenderer mt);
        for(int i = 0;i < mt.materials.Length;i++)
        {
            material.Add(mt.materials[i]);
        }
        return material;
    }

    void setMaterial(Save materials)
    {
        TryGetComponent(out MeshRenderer mt);
        List<Material> material = materials.
        mt.SetMaterials();
    }
}

enum MineTypes{
    copper = 1,
    iron,
    silver,
    gold
}