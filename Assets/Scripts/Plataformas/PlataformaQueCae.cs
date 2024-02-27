




/*using System.Collections;
using UnityEngine;

public class PlataformaQueCae : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;
    private Rigidbody2D rb2DPlataformaCae;
    [SerializeField] private float velocidadRotacion;

    private Animator animator;
    private bool caida = false;

    // Constante para el impulso horizontal
    private const float ImpulsoHorizontal = 0.1f;

    // Comentario explicando la inicialización
    private void Start()
    {
        rb2DPlataformaCae = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Comentario explicando la lógica de colisión
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Verificar si 'other' no es nulo y tiene la etiqueta "Player"
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(other));
        }
    }

    // Comentario explicando la lógica de la caída
    private IEnumerator Caida(Collision2D other)
    {
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;

        // Ignorar la colisión con el jugador
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());

        // Liberar las restricciones y aplicar fuerza horizontal
        rb2DPlataformaCae.constraints = RigidbodyConstraints2D.None;
        rb2DPlataformaCae.AddForce(new Vector2(ImpulsoHorizontal, 0));
    }
}*/


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

    // Método para restablecer la plataforma
   /* private void RestablecerPlataforma()
    {
        // Reiniciar posición y propiedades de la plataforma
        caida = false;
        rb2DPlataformaCae.constraints = RigidbodyConstraints2D.FreezeAll;
        rb2DPlataformaCae.velocity = Vector2.zero;

        // Establecer la posición original
        transform.position = posicionOriginal;
    }*/


// Método para restablecer la plataforma
private void RestablecerPlataforma()
{
    // Reiniciar posición y propiedades de la plataforma
    caida = false;
    rb2DPlataformaCae.constraints = RigidbodyConstraints2D.FreezeAll;
    rb2DPlataformaCae.velocity = Vector2.zero;

    // Establecer la posición original
    transform.position = posicionOriginal;

    // Temporalmente cambiar la capa de la plataforma a "Ignore Raycast"
    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

    // Establecer una pequeña espera antes de restaurar la capa original
    StartCoroutine(RestaurarCapaOriginal());
}

// Corrutina para restaurar la capa original después de un breve retraso
private IEnumerator RestaurarCapaOriginal()
{
    // Esperar un breve período de tiempo
    yield return new WaitForSeconds(0.1f); // Puedes ajustar este valor según sea necesario

    // Restaurar la capa original de la plataforma
    gameObject.layer = LayerMask.NameToLayer("Default");
}


}
