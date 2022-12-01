using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    public Text textoPersonaje;

    public string[] dialogo;
    public float textoVelocidad;
    public int textoActual;

    public void Start()
    {

    }

    public IEnumerator PrintText()
    {
        foreach (char item in dialogo[textoActual].ToCharArray()) // = Cuantos de estos hay en esto
        {
            textoPersonaje.text += item;
            yield return new WaitForSeconds(textoVelocidad);
        }
       
        yield return new WaitForSeconds(1);

        if (textoActual < dialogo.Length -1)
        {
            textoPersonaje.text = "";
            textoActual++;
            StartCoroutine(PrintText());
        }

        if (textoActual == dialogo.Length -1)
        {
            textoPersonaje.text = "";
        }

        yield return null;
    }

    public void LlamarCorrutina()
    {
        StartCoroutine(PrintText());
    }
}
