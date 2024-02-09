
using UnityEngine;



public class UserManager : MonoBehaviour
{
    // Método para crear y guardar un nuevo usuario con datos proporcionados
    public void CreateAndSaveUser(string userId, int puntosUsuario, int vidaUsuario)
    {
        // Crear un nuevo usuario con los datos proporcionados
        DataManager.User newUser = new DataManager.User
        {
            id = userId,
            puntosTotal = puntosUsuario,
            vidaGuardar = vidaUsuario,
        };

        // Guardar el nuevo usuario utilizando DataManager
        DataManager.instance.SaveData(newUser);
    }
}
