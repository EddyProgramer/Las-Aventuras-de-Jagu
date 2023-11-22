// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NewBehaviourScript : MonoBehaviour
// {
//     [SerializeField] private float tiempoEspera;
//     private Rigidbody2D rb2DPlataformaCae;
//       [SerializeField] private float velocidadRotacion;

//       private Animator animator;
//       private bool caida= false;

//       private void Start()
//       {
//         rb2DPlataformaCae = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
    
//       }

//       private void OnCollisionEnter2D(Collision2D other) 
//       {
//         if(other.gameObject.CompareTag("Player"))
//         {
//            StartCoroutine(Caida(other));
//         }
//       }

//       private IEnumerator Caida(Collision2D other)
//       {
//         yield return new WaitForSeconds(tiempoEspera);
//         caida=true;
//         Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(),other.transform.GetComponent<Collider2D>());
//         rb2DPlataformaCae.constraints = RigidbodyConstraints2D.None;
//         rb2DPlataformaCae.AddForce(new Vector2(0.1f,0));
//       }
// }




using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
}
