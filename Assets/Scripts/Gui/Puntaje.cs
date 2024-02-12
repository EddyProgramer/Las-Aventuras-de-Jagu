
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
  public int puntos;
//variable para guardar datos 
 public int puntosTemporal;

 // variable para manejo de datos en player prefs
 public int puntosPrefs;
  private TextMeshProUGUI textMesh;


  
  private void Start()
  {
    
    textMesh = GetComponent<TextMeshProUGUI>();

  }  
        
 
  private void Update()
  {
   // puntos = Time.deltaTime;
    textMesh.text = puntos.ToString("0");
  }

public void SumarPuntos(int puntosEntrada){
  
  puntos += puntosEntrada;
    
}

// MANEJO DE DATOS

   
    public int ObtenerPuntuacionUser() {
       puntosTemporal=puntos;
       // Guardar los puntos en PlayerPrefs
        PreviewLabs.PlayerPrefs.SetInt("PuntosGuardados", puntos);
        PreviewLabs.PlayerPrefs.Flush(); // Guardar los cambios inmediatamente
        Debug.Log("puntos enviados a player prefs: " + puntos);
        return puntosTemporal;
    }

    // Manejo de datos en player prefs

    public void SetearPuntaje(int puntajeSet){
      
      puntos=puntajeSet;


    }


}


  





