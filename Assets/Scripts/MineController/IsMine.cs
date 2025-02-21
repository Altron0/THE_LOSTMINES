using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IsMine : MonoBehaviour
{
    [SerializeField] GameObject mineUI;
    [SerializeField] GameObject exit;

    void OnCollisionEnter(Collision player)
    {
        exit.SetActive(true);  
    }

    void OnCollisionExit(Collision player)
    {
        exit.SetActive(false);
    }

    List<Material> getMaterial()
    {
        TryGetComponent(out MeshRenderer renderer);

        List<Material> mt = new List<Material>();
        for(int i = 0;i < renderer.materials.Length;i++)
        {
            mt.Add(renderer.materials[i]);
        }
        return mt;
    }


    void setMaterial(List<Material> mt)
    {
        TryGetComponent(out MeshRenderer renderer);
        renderer.SetMaterials(mt);
    }

    
}
struct Item
{
    public int id;
    public int count;
}
