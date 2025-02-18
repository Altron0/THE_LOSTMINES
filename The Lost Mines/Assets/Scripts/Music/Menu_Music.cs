using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Music : MonoBehaviour
{
    [SerializeField] Canvas UI;

    void Update()
    {
        UI.transform.TryGetComponent(out AudioSource audio);
        gameObject.TryGetComponent(out Toggle toggle);
       
        if (toggle.isOn == true) 
        {
            audio.mute = false;
        }
        else 
        {
            audio.mute = true;
        }
    }

}
