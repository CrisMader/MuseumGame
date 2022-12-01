using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int id;
    public float[] Precio;
    public PlayerController player;
    
    public GameObject parentPeluches;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().monedas == 3)
        {
            parentPeluches.transform.GetChild(5).gameObject.SetActive(true);
        }
    }

    public void CambiarID(int panel)
    {
        id = panel;
    }

    public void Comprar()
    {
        if (player.monedas >= Precio[id])
        {
            player.monedas -= Precio[id];
            parentPeluches.transform.GetChild(id).gameObject.SetActive(true);
        }
        else
        {
            player.textoMonedas.text = "No puedo dártelo si no tienes dinero";
        }

    }

    public void Vender()
    {
            player.monedas += Precio[id];
            parentPeluches.transform.GetChild(id).gameObject.SetActive(false);
    }

    /*public void CrearPanel(Slider slider)
    {
       

        GameObject panel = Instantiate(Plantilla, contentVenta.transform);
        panel.transform.GetChild(1).GetComponent<Image>().sprite = sprites[id];
        panel.transform.GetChild(4).GetComponent<Slider>().maxValue = slider.value;
        panel.transform.GetChild(5).GetComponent<Text>().text = Precio[id].ToString();
        panel.transform.GetChild(6).GetComponent<Text>().text = Content.transform.GetChild(id).GetChild(6).GetComponent<Text>().text;
        panel.name = Content.transform.GetChild(id).name;
    }*/

    /*for (int c = 0; c < contentVenta.transform.childCount; c++)
                {
                    if (Content.transform.GetChild(id).name == contentVenta.transform.GetChild(c).name)
                    {

                    
                }

                if (Content.transform.GetChild(id).GetChild(4).GetComponent<Slider>().maxValue > 20)
                {
                    CrearPanel(slider, PrecioTotal);
                    return;

                }*/


    /*if (Content.transform.GetChild(id).name == contentVenta.transform.GetChild(i).name)
    {
        contentVenta.transform.GetChild(i).GetChild(4).GetComponent<Slider>().maxValue += slider.value;
        money -= Precio[id] * slider.value;
        ActualizarDinero();
        return;
    }
    else if(i == contentVenta.transform.childCount -1)
    {
        CrearPanel(slider, PrecioTotal);
        return;
    }*/


}
