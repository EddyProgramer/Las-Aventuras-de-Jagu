using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
  private Rigidbody2D rb2D;  
//recibir daño
 public bool SePuedeMover=true;
 [SerializeField] private Vector2 velocidadRebote;
//variable para saltar
private Vector2 input;

  private float movimientoHorizontal = 0f;

  [SerializeField]private float velocidadMovimiento;
   
 [Range(0,0.3f)] [SerializeField] private float suavizadoDeMovimiento;

  private Vector3 velocidad = Vector3.zero;

  private bool mirandoDerecha = true;

  [Header("Salto")]

  [SerializeField] private float fuerzaSalto;

  [SerializeField] private LayerMask queEsSuelo;

  [SerializeField] private Transform controladorSuelo;

  [SerializeField] private Vector3 dimensionesCaja;

  [SerializeField] private bool enSuelo;

  private bool salto= false;

[Header("Animacion")]
  [SerializeField] private ParticleSystem particulas;
 private Animator animator;
  private void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    //lineas subir escaleras
    boxCollider2D = GetComponent<BoxCollider2D>();
    gravedadInicial = rb2D.gravityScale;
  }
// subir escaleras
  [Header("Escalar")]
   
   [SerializeField] private float velocidadEscalar;

   private BoxCollider2D boxCollider2D;
   private float gravedadInicial;
   private bool escalando;
//  --------------------------------------///
  private void Update()
  {
    //lineas para subir escaleras
    input.x = Input.GetAxisRaw("Horizontal");
      input.y = Input.GetAxisRaw("Vertical");
    movimientoHorizontal = Input.GetAxisRaw("Horizontal")* velocidadMovimiento;
    
    animator.SetFloat("Horizontal",Mathf.Abs (movimientoHorizontal));

    if(Input.GetButtonDown("Jump")){

      salto= true;
    }
  }
 

  private void FixedUpdate()
  {

    enSuelo = Physics2D.OverlapBox(controladorSuelo.position,dimensionesCaja,0f,queEsSuelo);
    //Mover
    
    //recibir daño script
    if (SePuedeMover)
    {
      Mover(movimientoHorizontal * Time.fixedDeltaTime,salto);

    }
   

    salto = false;
  }

  private void Mover (float mover, bool saltar){
    Vector3 velocidadObjetivo = new Vector2(mover,rb2D.velocity.y);

  rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity,velocidadObjetivo,ref velocidad, suavizadoDeMovimiento);

   if(mover>0 && !mirandoDerecha)
   {
       
    //Girar
    Girar();
   }
   else if (mover< 0 && mirandoDerecha){
        
         
    //Girar
     Girar();
   }

   if(enSuelo && saltar){
       enSuelo = false;
       rb2D.AddForce(new Vector2(0f, fuerzaSalto));
       particulas.Play();

   }
      // invocacion al metodo subir escaleras
      Escalar();
  }

  //metodo rebote recibir daño
  public void Rebote(Vector2 puntoGolpe)
  {
    rb2D.velocity=new Vector2(-velocidadRebote.x *puntoGolpe.x,velocidadRebote.y);

  }


  private void Girar ( ){
    mirandoDerecha = !mirandoDerecha;
    Vector3 escala = transform.localScale;
    escala.x*=-1;
    transform.localScale = escala;
    particulas.Play();
  }
// metodo para subir escaleras

   private void Escalar()
   {
    if((input.y !=0 || escalando)&& (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras"))))
     {
      Vector2 velocidadSubida = new Vector2(rb2D.velocity.x, input.y* velocidadEscalar);
      rb2D.velocity = velocidadSubida;
      rb2D.gravityScale = 0;
      escalando = true;
     }
     else
     {
      rb2D.gravityScale = gravedadInicial;
      escalando = false;

     }

     if(enSuelo)
     {
      escalando = false;
     }

   }
  
   private void OnDrawGizmos()
   {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube(controladorSuelo.position,dimensionesCaja);
   }
}
