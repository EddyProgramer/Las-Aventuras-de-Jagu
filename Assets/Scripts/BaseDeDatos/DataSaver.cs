using UnityEngine;
using Proyecto26;

public class DataSaver : MonoBehaviour
{
    private const string basePath = "https://cute-pothos-1aa00d.netlify.app/"; // Reemplaza con tu URL de la API

    // Método para guardar datos en el servidor
    public void GuardarDatos(int puntuacion, int vida, Vector2 posicion)
    {
        RestClient.Post(basePath + "/guardarDatos", new DatosJugador
        {
            Puntuacion = puntuacion,
            Vida = vida,
            PosicionX = posicion.x,
            PosicionY = posicion.y
        }).Then(response =>
        {
            Debug.Log("Datos guardados exitosamente en el servidor.");
        }).Catch(err => Debug.LogError("Error al guardar datos: " + err.Message));
    }

    // Método para cargar datos desde el servidor
    public void CargarDatos()
    {
        RestClient.Get<DatosJugador>(basePath + "/cargarDatos").Then(response =>
        {
            Debug.Log("Datos cargados exitosamente desde el servidor: Puntuación: " + response.Puntuacion + ", Vida: " + response.Vida + ", Posición: (" + response.PosicionX + ", " + response.PosicionY + ")");
        }).Catch(err => Debug.LogError("Error al cargar datos: " + err.Message));
    }

    // Definición de la clase para los datos del jugador
    private class DatosJugador
    {
        public int Puntuacion { get; set; }
        public int Vida { get; set; }
        public float PosicionX { get; set; }
        public float PosicionY { get; set; }
    }
}
