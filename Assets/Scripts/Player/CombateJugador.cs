
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vidaJagu;
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private AudioSource audioSourceDaño;
 [SerializeField] private AudioSource sonidoFondoAudioSource; // Nueva variable pública
    private MovimientoJugador movimientoJugador;
    private Animator animator;
    private Rigidbody2D rb2D;

    #region Unity Callbacks
    private void Start()
    {
        InicializarComponentes();
    }

    private void Update()
    {
        if (vidaJagu > 0)
        {
            Debug.Log("Vida mayor a cero");
        }
        else
        {
           Debug.Log("Llamando a GestionarMuerte");
            GestionarMuerte();
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
    #endregion

    #region Métodos Privados
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

 private void GestionarMuerte()
{
   Debug.Log("GestionarMuerte llamado");
   Debug.Log("Activando trigger Muerte");
  animator.SetTrigger("Muerte");
    Physics2D.IgnoreLayerCollision(6, 7, true);
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
       // Activar el trigger de muerte en el Animator
Debug.Log("Activando trigger Muerte");
animator.SetTrigger("Muerte");
    Time.timeScale = 0f;

    
    DesactivarObjeto();
    DesactivarSonidoFondo();
  
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
   
    // Opcionalmente, también podrías desactivar otros componentes o realizar otras acciones necesarias.
    // Por ejemplo, puedes desactivar el script actual si es necesario.
    // this.enabled = false;
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