using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class IsMine : MonoBehaviour
{
    [SerializeField] public GameObject mineUI;
    public int id;
    [SerializeField] GameObject exit;
    int hearth = 10;
    [SerializeField] Image[] materialsImage = new Image[4];

    void OnCollisionEnter(Collision player)
    {
        exit.SetActive(true);  
        exit.TryGetComponent(out Button button);
        button.onClick.AddListener(hearthOri);
    }

    void hearthOri()
    {
        hearth--;
        if(hearth == 0)
        {
            foreach(Inventory slot in GetComponentsInChildren<Inventory>())
            {
                if(slot.id == 0)
                {
                    slot.TryGetComponent(out Image image);
                    image = materialsImage[id];
                    mineUI.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
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
// struct Item
// {
//     public int id;
//     public int count;
// }
