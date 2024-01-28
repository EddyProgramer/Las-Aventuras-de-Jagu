using UnityEngine;

public class CuracionObjeto : MonoBehaviour
{
    [SerializeField] private float cantidadDeCuracion = 20f;
    [SerializeField] private AudioSource sonidoCuracion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player".
        {
             Debug.Log("Colisión con el jugador detectada");
            CurarJugador(other.gameObject);
            ReproducirSonidoCuracion();
            DesaparecerObjeto();
        }
    }

    private void CurarJugador(GameObject jugador)
    {
        CombateJugador scriptCombateJugador = jugador.GetComponent<CombateJugador>();

        if (scriptCombateJugador != null)
        {
            scriptCombateJugador.AumentarVida(cantidadDeCuracion);
        }
    }

    private void ReproducirSonidoCuracion()
    {

        Debug.Log("Reproduciendo sonido de curación");
      
       
        if (sonidoCuracion != null && sonidoCuracion.clip != null)
        {
              sonidoCuracion.PlayOneShot(sonidoCuracion.clip);
        }
         else
       {
        Debug.LogWarning("AudioSource de curación no está configurado correctamente.");
       }
    }
    

    private void DesaparecerObjeto()
    {
        gameObject.SetActive(false);
        // También podrías destruir el objeto si prefieres (Destroy(gameObject);).
    }
}
