using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
     private MovimientoJugador movimientoJugador;
     [SerializeField] private float tiempoPerdidaControl;
      [SerializeField] private float maximoVida;
      [SerializeField] public BarraDeVida barraDeVida;
    // private Animator animator;
//creacion de evento
public event EventHandler MuerteJugador;



  public void Start(){
    vida = maximoVida;
        barraDeVida =GetComponent<BarraDeVida>();
    barraDeVida.InicializarBarraDeVida(vida);
    movimientoJugador =GetComponent<MovimientoJugador>();

      
  //   animator = GetComponent<Animator>();
  }
    
   public void TomarDaño(float daño)
    {
        vida-= daño;
      
       

    }
   
//codigo chat Gpt
//    public void TomarDaño(float daño)
// {
//     vida -= daño;
//     barraDeVida.CambiarVidaActual(vida);
//     if (vida <= 0)
//     {
//         // Espera 0.1 segundos antes de destruir el objeto
//         Invoke("DestruirObjeto", 0.1f);
//     }
// }

//private void DestruirObjeto()
// {
//     Destroy(gameObject);
// }


    public void TomarDaño(float daño,Vector2 posicion)
    
    {
      vida -=daño;
     
     if (vida>0)
     {

      barraDeVida.CambiarVidaActual(vida);
       Debug.Log("vida mayor a cero");
      //linea para animacion de daño
       //  animator.SetTrigger("Golpe");
     }
       else
       {
        //linea para animacion de muerte
        //  animator.SetTrigger("Muerte");
      
        Physics2D.IgnoreLayerCollision(6,7,true);
        MuerteJugadorEvento();
          DestruirObjeto();
       }
       StartCoroutine(PerderControl());
      StartCoroutine(DesactivarColision());
       movimientoJugador.Rebote(posicion);
    }
    //invocar evento
    public void MuerteJugadorEvento()
    {
     MuerteJugador?.Invoke(this,EventArgs.Empty);

    }

    private void DestruirObjeto()
     {
     Destroy(gameObject);
      }

       private IEnumerator DesactivarColision()
      {
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6,7,false);
      }

      private IEnumerator PerderControl()
      {
        movimientoJugador.SePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.SePuedeMover = true;
      }

}
