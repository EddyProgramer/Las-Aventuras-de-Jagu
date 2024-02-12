
using UnityEngine;

public class PosicionJagu : MonoBehaviour
{

float posicionX;

float posicionY;

Vector2 posicionXVector;

//METODO PARA OBTENER LA POSICION DEL PLAYER

// metodos para obtener la posición del jugador en X y Y
    public float ObtenerPosicionUserX()
    {
    
         posicionX = transform.position.x;

           // Guardar los puntos en PlayerPrefs
        PreviewLabs.PlayerPrefs.SetFloat("posicionX", posicionX);
        PreviewLabs.PlayerPrefs.Flush(); // Guardar los cambios inmediatamente
        Debug.Log("posicion X enviado a player prefs: " + posicionX);
        return posicionX;

    }

    public Vector2 SetPosicionPlayer(Vector2 posicionXVector){



      return posicionXVector;
    }
 public float ObtenerPosicionUserY()
    {
    
         posicionY = transform.position.y;

           // Guardar los puntos en PlayerPrefs
        PreviewLabs.PlayerPrefs.SetFloat("posicionY", posicionY);
        PreviewLabs.PlayerPrefs.Flush(); // Guardar los cambios inmediatamente
        Debug.Log("posicion X enviado a player prefs: " + posicionY);

        return posicionY;
        
    }

        public void SetPositionX(float positionX)
    {
        // Obtenemos la posición actual del objeto
        Vector2 posicionActual = transform.position;

        // Asignamos la nueva posición en X
        posicionActual.x = positionX;

        // Asignamos la posición actualizada al objeto
        transform.position = posicionActual;
    }
     // Método para asignar la posición en Y del objeto
    public void SetPositionY(float positionY)
    {
        // Obtenemos la posición actual del objeto
        Vector2 posicionActual = transform.position;

        // Asignamos la nueva posición en Y
        posicionActual.y = positionY;

        // Asignamos la posición actualizada al objeto
        transform.position = posicionActual;
    }



}
