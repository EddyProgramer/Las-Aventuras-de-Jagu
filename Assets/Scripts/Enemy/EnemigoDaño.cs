using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemigoDaño : MonoBehaviour
{

    private Animator animator;

    private void Start() {
     animator= GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.CompareTag("Player"))
    {
       if(other.GetContact(0).normal.y <= -0.9){

          animator.SetTrigger("Golpe");
          other.gameObject.GetComponent<MovimientoJugador>().ReboteE();
       }
       // causar daño al Player
       other.gameObject.GetComponent<CombateJugador>().TomarDaño(20,other.GetContact(0).normal);
      }
    }
//Destruir objeto enemigo luego de recibir daño
    public void Golpe(){
     
     Destroy(gameObject);
    }
    }

    

