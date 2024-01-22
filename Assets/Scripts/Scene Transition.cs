using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(string Nivel1)
    {
        SceneManager.LoadScene(Nivel1);
    }
}
