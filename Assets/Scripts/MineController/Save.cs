using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Save : MonoBehaviour
{
    string path;
   void Start()
   {
    path = Path.GetFullPath("./");
   }

   void ParseToJson()
   {

   }

   string PareFromJson()
   {
    return "";
   }
   void SaveFile(string fileName, string information)
   {
    StreamWriter sw = new StreamWriter(path + fileName);
    sw.Write(information);
    sw.Close();
   }

   string LoadFile(string fileName)
   {
    StreamReader sr = new StreamReader(path + fileName);
    string data = sr.ReadLine();

    return data;
   }


}
