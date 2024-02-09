
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
  public int puntos;
//variable para guardar datos 
 public int puntosTemporal;
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
        return puntosTemporal;
    }
}


  





