
using UnityEngine;




public class ControlPuerta : MonoBehaviour
{
    public bool abierta = false;
        private bool jaguEstaCerca;
    public Sprite spritePuertaCerrada;
    public Sprite spritePuertaAbierta;

    public AudioClip sonidoPuertaAbierta;
    public AudioClip sonidoPuertaCerrada;
   
    [SerializeField] private AudioSource EnterSound;
     [SerializeField] private GameObject signoInterrogacion;
   [SerializeField] private GameObject teclaE;

    private SpriteRenderer spriteRenderer;
    private Collider2D colliderPuerta;
    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderPuerta = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();

        // Asegúrate de que el spriteRenderer, el colliderPuerta y el audioSource no sean nulos
        if (spriteRenderer != null && colliderPuerta != null && audioSource != null)
        {
            // Asigna el sprite inicial
            spriteRenderer.sprite = abierta ? spritePuertaAbierta : spritePuertaCerrada;

            // Activa o desactiva el collider según el estado de la puerta
            colliderPuerta.enabled = !abierta;
        }
    }

    void Update()
    {

           if (jaguEstaCerca && Input.GetKeyDown(KeyCode.E))
        {
              TogglePuerta();
        
        }
       
         
    }

    void TogglePuerta()
    {
        abierta = !abierta;

        // Reproduce el sonido correspondiente
        if (audioSource != null)
        {
            audioSource.clip = abierta ? sonidoPuertaAbierta : sonidoPuertaCerrada;
            audioSource.Play();
        }

        // Cambia la posición de la puerta según si está abierta o cerrada
        if (abierta)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }

        // Cambia el sprite de la puerta según su estado
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = abierta ? spritePuertaAbierta : spritePuertaCerrada;
        }

        // Activa o desactiva el collider según el estado de la puerta
        if (colliderPuerta != null)
        {
            colliderPuerta.enabled = !abierta;
        }
    }


    private void  OnTriggerEnter2D(Collider2D Collision) {
     
       if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCerca= true;
         signoInterrogacion.SetActive(true);
         teclaE.SetActive(true);
           if (EnterSound != null) // Verifica si hay un sonido de entrada asignado
            {
                EnterSound.Play(); // Reproduce el sonido de entrada si está asignado
            }

       }
       
        

        
    }

    private void OnTriggerExit2D(Collider2D Collision) {
         if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCerca = false;
            signoInterrogacion.SetActive(false);
             teclaE.SetActive(false);
       }
       
    }
}
