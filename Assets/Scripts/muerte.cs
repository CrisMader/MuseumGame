using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerte : MonoBehaviour
{
    public bool ganarMonedas;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameObject.Find("Player").transform.position = new Vector2(5.5f, 1.2f);
            GameObject.Find("Player").GetComponent<PlayerController>().inicio.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerController>().Goku.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerController>().Idle.SetActive(true);
            GameObject.Find("Minijuego").SetActive(false);
            
            //Fin del videojuego de Flappy Bird
            //Puedo poner texto de haber perdido
            //Puedo resetear la posicion del player
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (ganarMonedas == false)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().monedas++;
            ganarMonedas = true;
        }
       
    }
}
