using System.Collections;
using UnityEngine;
using TMPro;

public class NarrativeMessages : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] mensajes; // Arreglo con los textos narrativos
    public TextMeshProUGUI textoUI;
    public float velocidadEscritura = 0.05f; // Velocidad del efecto "escritura"
    public float tiempoEntreMensajes = 2f;

    private void Start()
    {
        StartCoroutine(MostrarMensajes());
    }

    IEnumerator MostrarMensajes()
    {
        foreach (string mensaje in mensajes)
        {
            yield return StartCoroutine(EscribirTexto(mensaje));
            yield return new WaitForSeconds(tiempoEntreMensajes);
            textoUI.text = "";
        }
    }

    IEnumerator EscribirTexto(string mensaje)
    {
        textoUI.text = "";
        foreach (char letra in mensaje)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }
    }
}

