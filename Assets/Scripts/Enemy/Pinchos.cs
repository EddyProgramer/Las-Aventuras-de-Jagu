using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public AudioClip golpePsoundClip; // Asigna el sonido desde el inspector
    private AudioSource audioSource; // crear audio source
    private Animator animator;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Inicializar el AudioSource
        animator = GetComponent<Animator>(); // Inicializar el Animator
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        // Reproducir sonido
        if (golpePsoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(golpePsoundClip);
        }

        // Activar la animación
        if (animator != null)
        {
            animator.SetTrigger("Golpe");
        }

        // Llamar al método TomarDaño del componente CombateJugador del jugador
        // causar daño al Player
        CombateJugador combateJugador = other.gameObject.GetComponent<CombateJugador>();
        if (combateJugador != null)
        {
            combateJugador.TomarDaño(100, other.GetContact(0).normal);
        }
    }
}
}
