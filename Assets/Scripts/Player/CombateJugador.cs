
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vidaJagu;
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private AudioSource audioSourceDaño;
      [SerializeField] private AudioSource audioSourceMuerte;
 [SerializeField] private AudioSource sonidoFondoAudioSource; // Nueva variable pública

  // Nuevo campo para referenciar el objeto MenuMuerte
    [SerializeField] private GameObject menuMuerteObjeto;
    private MovimientoJugador movimientoJugador;
    private Animator animator;
    private Rigidbody2D rb2D;

    //variables para controlar muerte por caida
    private bool enCaidaLibre = false;
    private float tiempoEnCaidaLibre = 0f;

    #region Unity Callbacks
    private void Start()
    {
        InicializarComponentes();
    }

  private void Update()
    {
        if (vidaJagu > 0)
        {
            if (EstaEnCaidaLibre())
            {
                tiempoEnCaidaLibre += Time.deltaTime;

                if (tiempoEnCaidaLibre > 3f)
                {
                    IniciarSecuenciaDeMuerte();
                }
            }
            else
            {
                tiempoEnCaidaLibre = 0f; // Reinicia el contador si no está en caída libre
            }

            Debug.Log("Vida mayor a cero");
        }
        else
        {
            Debug.Log("Llamando a GestionarMuerte");
            IniciarSecuenciaDeMuerte();
        }
    }
    #endregion

    #region Métodos Públicos
    public void TomarDaño(float daño)
    {
        vidaJagu -= daño;
        ActualizarBarraDeVida();
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vidaJagu -= daño;
        animator.SetTrigger("JaguDaño");
        ReproducirSonidoDanio();
        movimientoJugador.ReboteDaño(posicion);
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        ActualizarBarraDeVida();
    }

   public void AumentarVida(float cantidad)
{
    vidaJagu += cantidad;

    // Asegurarse de que la vida no exceda el límite máximo (100 en este caso)
    vidaJagu = Mathf.Clamp(vidaJagu, 0f, 100f);

    ActualizarBarraDeVida();
}


    #endregion

    #region Métodos Privados


        private bool EstaEnCaidaLibre()
    {
        // Puedes ajustar estos valores según la velocidad de caída de tu personaje
        float velocidadMinimaCaida = -5f;

        // Verifica si la velocidad vertical es suficientemente baja para considerarse caída libre
        enCaidaLibre = rb2D.velocity.y < velocidadMinimaCaida;

        return enCaidaLibre;
    }
    private void InicializarComponentes()
    {
        movimientoJugador = GetComponent<MovimientoJugador>();
     //   audioSourceDaño = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
       
            barraDeVida = FindObjectOfType<BarraDeVida>();

        if (barraDeVida != null)
        {
            barraDeVida.InicializarBarraDeVida(vidaJagu);
        }
        else
        {
            Debug.LogWarning("La referencia a BarraDeVida es null. verificar  asignacion del componente en el Inspector.");
        }
    }


private IEnumerator GestionarMuerteCoroutine()
{
    Debug.Log("GestionarMuerte llamado");

    // Check if the animator and trigger are properly set up
    if (animator != null)
    {
        Debug.Log("Activando trigger Muerte");
         // Double-check layer collision ignoring
    Physics2D.IgnoreLayerCollision(6, 7, true);
         
        animator.SetTrigger("Muerte");
        
        
             ReproducirSonidoMuerte();
          
    yield return new WaitForSeconds(1.5f);
            
    }
    else
    {
        Debug.LogWarning("Animator is null. Make sure it's assigned in the Inspector.");
    }

    // Esperar un segundo
   // Reemplaza esta línea


// con este bloque de código
float elapsedTime = 0f;
float waitTime = 1.5f;

while (elapsedTime < waitTime)
{
    elapsedTime += Time.unscaledDeltaTime;
    yield return null; // Esperar un frame
}

       // Mostrar el objeto MenuMuerte activándolo
        if (menuMuerteObjeto != null)
        {
              Debug.Log("Llamando a MenuMuerte");
            menuMuerteObjeto.SetActive(true);
             Physics2D.IgnoreLayerCollision(6, 7, false);
        }
        else
        {
            Debug.LogWarning("Objeto MenuMuerte no asignado en el Inspector.");
        }

  

    // Freeze rigidbody and pause the game
    if (rb2D != null)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    else
    {
        Debug.LogWarning("Rigidbody2D is null. Make sure it's assigned in the Inspector.");
    }

 Time.timeScale = 0f;
    // Attempt to deactivate the object and background sound
    DesactivarObjeto();
    DesactivarSonidoFondo();

}

// Llamas a este método desde donde quieras iniciar la secuencia de muerte
private void IniciarSecuenciaDeMuerte()
{
    StartCoroutine(GestionarMuerteCoroutine());
}

   private void DesactivarSonidoFondo()
    {
        // Verificar si se asignó el AudioSource del sonido de fondo en el Inspector
        if (sonidoFondoAudioSource != null)
        {
            // Desactivar el AudioSource
            sonidoFondoAudioSource.enabled = false;
        }
        else
        {
            Debug.LogWarning("La referencia a AudioSource del sonido de fondo no está asignada en el Inspector.");
        }
    }
private void DesactivarObjeto()
{
    gameObject.SetActive(false);
   
    /* Opcionalmente, también podrías desactivar otros componentes o realizar otras acciones necesarias.
     Por ejemplo, puedes desactivar el script actual si es necesario.
     this.enabled = false;n */
}

    private void ReproducirSonidoDanio()
    {
        if (audioSourceDaño != null && audioSourceDaño.clip != null)
        {
            audioSourceDaño.PlayOneShot(audioSourceDaño.clip);
        }
        else
        {
            Debug.LogWarning("AudioSourceDaño no asignado o clip no configurado.");
        }
    }

private void ReproducirSonidoMuerte()
    {
        if (audioSourceMuerte != null && audioSourceMuerte.clip != null)
        {
            audioSourceMuerte.PlayOneShot(audioSourceMuerte.clip);
        }
        else
        {
            Debug.LogWarning("AudioSourceMuete no asignado o clip no configurado.");
        }
    }

    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    private IEnumerator PerderControl()
    {
        movimientoJugador.SePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.SePuedeMover = true;
    }

    private void ActualizarBarraDeVida()
    {
        if (barraDeVida != null)
        {
            barraDeVida.CambiarVidaActual(vidaJagu);
        }
        else
        {
            Debug.LogWarning("La referencia a BarraDeVida es null. Asegúrate de haber asignado el componente en el Inspector.");
        }
    }
    #endregion
}