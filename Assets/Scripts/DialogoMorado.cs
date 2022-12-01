using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoMorado : MonoBehaviour
{
    public Text textoMorado;

    public string[] dialogoTres;
    public float textoVelocidad;
    public int textoActual;

    public void Start()
    {

    }

    public IEnumerator MoradoHabla()
    {
        foreach (char item in dialogoTres[textoActual].ToCharArray()) // = Cuantos de estos hay en esto
        {
            textoMorado.text += item;
            yield return new WaitForSeconds(textoVelocidad);
        }

        yield return new WaitForSeconds(1);

        if (textoActual < dialogoTres.Length - 1)
        {
            textoMorado.text = "";
            textoActual++;
            StartCoroutine(MoradoHabla());
        }

        if (textoActual == dialogoTres.Length - 1)
        {
            textoMorado.text = "";
        }

        yield return null;
    }

    public void LlamarCorrutinaMorado()
    {
        StartCoroutine(MoradoHabla());
    }
}
