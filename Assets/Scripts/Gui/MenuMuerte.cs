
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{



    [SerializeField] public GameObject menuMuerte;


     public MenuPausa menuPausa;
  

   
   public void Reiniciar(){
 //menuPausa = FindObjectOfType<MenuPausa>();
    //REINICIAR JUEGO EN BASE A PLAYER PREFS
   
    //Time.timeScale = 0f;  

      //  Time.timeScale = 1f;  

   }

   public void Cerrar (){

        SceneManager.LoadScene("MenuPrincipal");
  
   }
 }

