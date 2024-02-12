
using UnityEngine;

public class ClearPlayerPrefsButton : MonoBehaviour
{
 

    private void Start()
    {
        
    }

    public void ClearPlayerPrefs()
    {
        PreviewLabs.PlayerPrefs.DeleteAll();// Borra PlayerPrefs usando la función estándar de Unity
         // Notifica al editor de PlayerPrefs de PreviewLabs que los PlayerPrefs han sido actualizados
        PreviewLabs.PlayerPrefs.Flush();
        Debug.Log("player prefs borrados" );
    }
}
