using System.IO;
using UnityEngine;
using PreviewLabs;

public class PlayerPrefsChecker : MonoBehaviour
{
 void Start()
{
    string filePath = PlayerPrefsFilePath();
    if (File.Exists(filePath))
    {
        byte[] data = File.ReadAllBytes(filePath);
        // Convierte los bytes a una cadena legible si es necesario
        string dataString = System.Text.Encoding.UTF8.GetString(data);
        Debug.Log("PlayerPrefs data: " + dataString);
    }
    else
    {
        Debug.LogWarning("PlayerPrefs file not found!");
    }
}


    string PlayerPrefsFilePath()
    {
        string path = Application.persistentDataPath;
        string companyName = Application.companyName;
        string productName = Application.productName;
        return Path.Combine(path, "prefs");
    }
}
