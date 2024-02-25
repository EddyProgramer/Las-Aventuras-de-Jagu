
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{



    [SerializeField] public GameObject menuMuerte;



  

   
   public void Reiniciar(){

    //REINICIAR JUEGO EN BASE A PLAYER PREFS
    
   }

   public void Cerrar (){

        SceneManager.LoadScene("MenuPrincipal");
  
   }
 }

