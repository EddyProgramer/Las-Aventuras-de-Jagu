 





using System.Collections;
using UnityEngine;

public class PlataformaQueCae : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;
    [SerializeField] private float tiempoRegeneracion = 3f; // Tiempo de regeneración
    private Rigidbody2D rb2DPlataformaCae;
    [SerializeField] private float velocidadRotacion;

    private Animator animator;
    private bool caida = false;
    private Vector3 posicionOriginal; // Almacena la posición original de la plataforma
    private Quaternion rotacionOriginal; // Almacena la rotación original de la plataforma


    // Constante para el impulso horizontal
    private const float ImpulsoHorizontal = 0.1f;

    // Comentario explicando la inicialización
    private void Start()
    {
        rb2DPlataformaCae = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Almacenar la posición original al inicio
        posicionOriginal = transform.position;
    }

    // Comentario explicando la lógica de colisión
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Verificar si 'other' no es nulo y tiene la etiqueta "Player"
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(other.collider));
        }
    }

    // Comentario explicando la lógica de la caída
    private IEnumerator Caida(Collider2D playerCollider)
    {
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;

        // Ignorar la colisión con el jugador
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);

        // Liberar las restricciones y aplicar fuerza horizontal
        rb2DPlataformaCae.constraints = RigidbodyConstraints2D.None;
        rb2DPlataformaCae.AddForce(new Vector2(ImpulsoHorizontal, 0));

        // Esperar un tiempo antes de regenerar la plataforma
        yield return new WaitForSeconds(tiempoRegeneracion);

        // Restablecer la plataforma
      RestablecerPlataforma();
    }

    
private void RestablecerPlataforma()
{
    // Reiniciar posición y propiedades de la plataforma
    caida = false;
    rb2DPlataformaCae.constraints = RigidbodyConstraints2D.FreezeAll;
    rb2DPlataformaCae.velocity = Vector2.zero;

    transform.position = posicionOriginal;
     transform.rotation = rotacionOriginal;

   // Por ejemplo, si el jugador tiene un Rigidbody2D, podrías obtener el collider de esta manera:
Rigidbody2D playerRigidbody = FindObjectOfType<CombateJugador>().GetComponent<Rigidbody2D>(); // Asumiendo que PlayerController es el script que controla al jugador.
Collider2D playerCollider = playerRigidbody.GetComponent<Collider2D>();

// Ahora puedes activar la colisión así:
Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
}



}
