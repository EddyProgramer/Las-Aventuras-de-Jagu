using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
     [SerializeField] private Transform[] puntosMovimiento;


     [SerializeField] private float velocidadMovimiento;

     private int siguientePlataforma = 1;

     private bool ordenPlataformas = true;

 private void OnCollisionEnter(Collision other)
      {
            Debug.Log("OnCollisionEnter() called");

         if(other.gameObject.CompareTag("Player")){
            Debug.Log("Player entered the platform");
           other.transform.SetParent(this.transform);

         }
         
      }

      private void OnCollisionExit(Collision other)
      {
          Debug.Log("OnCollisionExit() called");

        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Player exited the platform");
           other.transform.SetParent(null);

         }
      }
    

   private void Update(){
        
        if(ordenPlataformas && siguientePlataforma +1 >= puntosMovimiento.Length){

            ordenPlataformas = false;
        }

          if(!ordenPlataformas && siguientePlataforma  <= 0){

            ordenPlataformas = true;
        }


        if(Vector2.Distance(transform.position, puntosMovimiento[siguientePlataforma].position)<0.1f){

               if (ordenPlataformas)
              {
                  siguientePlataforma ++;
               }
               else 
               {

                 siguientePlataforma --;
               }

               

        }
 


        transform.position = Vector2.MoveTowards(transform.position,puntosMovimiento[siguientePlataforma].position,
        velocidadMovimiento*Time.deltaTime);



        

   }

   
     
  
    

}


