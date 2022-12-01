using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailogoDos : MonoBehaviour
{
    public Text textoCanela;

    public string[] dialogodos;
    public float textoVelocidad;
    public int textoActual;

    public void Start()
    {

    }

    public IEnumerator CanelaHabla()
    {
        foreach (char item in dialogodos[textoActual].ToCharArray()) // = Cuantos de estos hay en esto
        {
            textoCanela.text += item;
            yield return new WaitForSeconds(textoVelocidad);
        }

        yield return new WaitForSeconds(1);

        if (textoActual < dialogodos.Length - 1)
        {
            textoCanela.text = "";
            textoActual++;
            StartCoroutine(CanelaHabla());
        }

        if (textoActual == dialogodos.Length - 1)
        {
            textoCanela.text = "";
        }

        yield return null;
    }

    public void LlamarCorrutinaCanela()
    {
        StartCoroutine(CanelaHabla());
    }
}
