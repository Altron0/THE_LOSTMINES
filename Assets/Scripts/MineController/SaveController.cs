using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveController : MonoBehaviour
{
   [SerializeField] mineController mineController; 
   [SerializeField] ISavable[] savableObjects = new ISavable[1];

   void Start()
   {
    savableObjects[0] = mineController;
   }

   void Save()
   {
    foreach (ISavable savable in savableObjects)
    {
        savable.Save();
    }
   }

   void Load()
   {
    foreach (ISavable savable in savableObjects)
    {
        savable.Load();
    }
   }
}

public interface ISavable
{
    void Save();

    void Load();
}
