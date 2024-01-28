using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TituloApareceDesvanece : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float velocidadDesvanecimiento = 0.5f;

    void Start()
    {
        // Asegúrate de que el CanvasGroup no sea nulo
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                Debug.LogError("El CanvasGroup no está asignado en el inspector o en el GameObject.");
            }
        }

        // Oculta el título al inicio
        OcultarTitulo();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador ha entrado en el área específica
        if (other.CompareTag("Player"))
        {
            // Muestra el título
            MostrarTitulo();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el jugador ha salido del área específica
        if (other.CompareTag("Player"))
        {
            // Oculta el título
            OcultarTitulo();
        }
    }

    void MostrarTitulo()
    {
        // Activa el CanvasGroup y comienza a desvanecer
        canvasGroup.alpha = 1f;
        StartCoroutine(DesvanecerTitulo());
    }

    void OcultarTitulo()
    {
        // Detiene cualquier corutina en progreso y establece la opacidad a cero
        StopAllCoroutines();
        canvasGroup.alpha = 0f;
    }

    IEnumerator DesvanecerTitulo()
    {
        // Desvanece gradualmente el título
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= velocidadDesvanecimiento * Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que la opacidad sea cero al finalizar
        canvasGroup.alpha = 0f;
    }
}
