using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuMuerte : MonoBehaviour
{



    [SerializeField] public GameObject menuMuerte;



  

   
   public void Reiniciar(){

    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void Cerrar (){

   // Debug.Log("Cerrando Juego");
        //Detener el Editor Para comprobar que el boton funciona
   // UnityEditor.EditorApplication.isPlaying = false;
    //Application.Quit();
   }
 }

