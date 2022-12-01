using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject canvasExpositor;
    public GameObject parentMinijuego;
    public GameObject canvasExplicacion;
    public GameObject expositor;
    public GameObject recreativa;
    public GameObject inicio;
    public GameObject canvasTienda;

    public GameObject Idle, Caminar, Goku;

    public Animator myAnim;

    public Text textoMonedas;
    public float monedas;
    
    //public float fuerzaSalto = 2f;
    void Start()
    {
        //Yep(5,8);
        //transform.position = new Vector2(-8.05f, 2.31f);
    }

    void Update()
    {
        textoMonedas.text = "Dinero: " + monedas.ToString();
        
        if (!canvasExpositor.activeSelf && !canvasTienda.activeSelf && !parentMinijuego.activeSelf)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            
            GetComponent<Rigidbody2D>().gravityScale = 0;

            transform.Translate(new Vector2(h, v) * 4 * Time.deltaTime);
            //expositor.SetActive(true);
            //recreativa.SetActive(true);

            if (h == 0 && v == 0)
            {
                //myAnim.Play("PIdle");
                Idle.SetActive(true);
                Caminar.SetActive(false);
            }
            else
            {
                //myAnim.Play("PAndar");
                Idle.SetActive(false);
                Caminar.SetActive(true);

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Caminar.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Caminar.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (parentMinijuego.activeSelf)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            


            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }

            if (GetComponent<Rigidbody2D>().velocity.y  < -4)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -4);
            }

            if (GetComponent<Rigidbody2D>().velocity.y > 4)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarCanvas();
            CerrarTienda();
            CerrarExplicacion();
            CerrarMinijuego();
        }



    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.tag == "Expositor")
            {
                canvasExpositor.SetActive(true);
                FindObjectOfType<Dialogos>().GetComponent<Dialogos>().LlamarCorrutina();
            }

            if (collision.gameObject.tag == "Recreativa")
            {
                inicio.SetActive(false);
                parentMinijuego.SetActive(true);
                Idle.SetActive(false);
                Caminar.SetActive(false);
                Goku.SetActive(true);

                transform.position = Vector2.zero; //Vector2.zero; = new Vector2 (0,0);
            }

            if (collision.gameObject.tag == "NPC")
            {
                canvasTienda.SetActive(true);
                FindObjectOfType<DailogoDos>().GetComponent<DailogoDos>().LlamarCorrutinaCanela();
            }

            if (collision.gameObject.tag == "Explicacion")
            {
                canvasExplicacion.SetActive(true);
                FindObjectOfType<DialogoMorado>().GetComponent<DialogoMorado>().LlamarCorrutinaMorado();
            }
        }

       
    }

    /*public int Yep(parametroUno, parametroDos)
    {
        return parametroUno + parametroDos;
    }*/
    public void CerrarCanvas()
    {
        canvasExpositor.SetActive(false);
    }

    public void CerrarTienda()
    {
        canvasTienda.SetActive(false);
    }

    public void CerrarExplicacion()
    {
        canvasExplicacion.SetActive(false);
    }

    public void CerrarMinijuego()
    {
        parentMinijuego.SetActive(false);
    }
    
    
    //Cuidado con poner IEnumerable
    /*public IEnumerator Patata()
    {
        print("Hola acabo de entrar a la corrutina");

        yield return new WaitForSeconds(2f);
        //WaitForSeconds sirve para poner un tiempo de espera para que después del print haga otra cosa (la unidades son segundos reales, no en unidades de Unity)
        print("Han Pasado 2 segundos :D");
        yield return null;
    }*/
}
