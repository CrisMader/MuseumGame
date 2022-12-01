using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public bool instanciar;
    public GameObject obs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 2 * Time.deltaTime);

        if (transform.position.x <= 2 && instanciar == false)
        {
            Instantiate(obs, new Vector2 (8, Random.Range(-3.0f, 3.0f)), Quaternion.identity);
            instanciar = true;
        }

        if (!GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>().parentMinijuego.activeSelf)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= -9)
        {
            Destroy(gameObject);
        }
    }
}
