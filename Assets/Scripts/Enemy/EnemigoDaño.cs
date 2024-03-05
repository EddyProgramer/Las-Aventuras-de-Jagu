


using UnityEngine;

public class EnemigoDaño : MonoBehaviour
{
    public AudioClip golpeSoundClip; // Asigna el sonido desde el inspector
    public float tiempoDesactivado = 5f; // Tiempo en segundos que el objeto estará desactivado

    private AudioSource audioSource;// crear audio source
    private Animator animator;

    private void Start() {
     animator= GetComponent<Animator>();

     audioSource = GetComponent<AudioSource>();
        // Si no hay un componente AudioSource, agregamos uno y configuramos el clip
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = golpeSoundClip;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetContact(0).normal.y <= -0.9)
            {
                // Reproducir sonido
                if (golpeSoundClip != null && audioSource != null)
                {
                    audioSource.PlayOneShot(golpeSoundClip);
                }

                // Activar la animación
                animator.SetTrigger("Golpe");

                // Hacer rebotar al jugador
                other.gameObject.GetComponent<MovimientoJugador>().ReboteE();

                // Retrasar la desactivación del objeto
                Invoke("DesactivarObjeto", 0.5f); // Ajusta el retraso según sea necesario

             
            }
            // causar daño al Player
            if (Mathf.Abs(other.GetContact(0).normal.x) >= 0.5f)
            {
                // Llamar al método TomarDaño del componente CombateJugador del jugador
                other.gameObject.GetComponent<CombateJugador>().TomarDaño(6, other.GetContact(0).normal);
            }
        }
    }
//Destruir objeto enemigo luego de recibir daño
    public void Golpe(){
     
    // Destroy(gameObject);
    }
      // Método para activar el objeto nuevamente después del tiempo especificado
    private void ActivarObjeto()
    {
        gameObject.SetActive(true);
    }

  // Método para desactivar el objeto después de un pequeño retraso
    private void DesactivarObjeto()
    {
        gameObject.SetActive(false);
        // Activar el objeto nuevamente después de un tiempo
        Invoke("ActivarObjeto", tiempoDesactivado);
    }



    }


