using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuMuerte : MonoBehaviour
{



    [SerializeField] private GameObject menuMuerte;

     private CombateJugador combateJugador;


private void Start()
{
    combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombateJugador>();
    combateJugador.MuerteJugador += AbrirMenu;

}

   public void AbrirMenu(object sender,EventArgs e)
   {
  
    menuMuerte.SetActive(true);
   }

   
   public void Reinciar(){

    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void Cerrar (){

    Debug.Log("Cerrando Juego");
    Application.Quit();
   }
 }

