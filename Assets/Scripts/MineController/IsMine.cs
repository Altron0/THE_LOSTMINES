using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class IsMine : MonoBehaviour
{
    
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
