using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MostrarMensajeZona : MonoBehaviour
{
    [Header("Mensaje UI")]
    public GameObject panelMensaje; // Panel o texto UI que se activará
    public string textoMensaje ;
    public TextMeshProUGUI textoUI; // Referencia a un componente Text (UI)

    void Start()
    {
        if (panelMensaje != null)
            panelMensaje.SetActive(false); // Asegura que empiece oculto
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (panelMensaje != null)
            {
                panelMensaje.SetActive(true);
                if (textoUI != null)
                    textoUI.text = textoMensaje;
                textoMensaje.ToString();
                
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (panelMensaje != null)
                panelMensaje.SetActive(false);
            // (opcional) puedes dejarlo visible si quieres que se mantenga
        }
    }
}
