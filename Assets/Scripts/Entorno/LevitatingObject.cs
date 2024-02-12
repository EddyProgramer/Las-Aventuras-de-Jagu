using UnityEngine;

public class LevitatingObject : MonoBehaviour
{
    public float velocidadMovimiento = 2f; // Ajusta la velocidad de movimiento según sea necesario
    public float amplitudMovimiento = 1f; // Ajusta la amplitud del movimiento según sea necesario

    private float inicioY;

    void Start()
    {
        inicioY = transform.position.y;
    }

    void Update()
    {
        // Calcula el desplazamiento vertical usando la función seno para obtener un movimiento ondulatorio
        float desplazamientoVertical = Mathf.Sin(Time.time * velocidadMovimiento) * amplitudMovimiento;

        // Aplica el desplazamiento al objeto
        Vector3 nuevaPosicion = new Vector3(transform.position.x, inicioY + desplazamientoVertical, transform.position.z);
        transform.position = nuevaPosicion;
    }
}
