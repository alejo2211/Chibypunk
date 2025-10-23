using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraPathWithFade : MonoBehaviour
{
    [Header("Configuración de la cámara")]
    public Transform mainCamera;
    public Transform[] camPoints;
    public float moveSpeed = 2f;
    public float waitTime = 2f;

    [Header("Efecto de fade")]
    public CanvasGroup fadeCanvas;

    [Header("Mensaje final")]
    public GameObject continueMessage;   // Texto "Presiona ENTER para continuar"

    [Header("Cambio de escena")]
    public SceneChangeManager sceneManager;
    public string nextSceneName = "Level1";

    private bool canContinue = false; // Indica si ya puede continuar

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main.transform;

        if (fadeCanvas != null)
        {
            fadeCanvas.alpha = 0;
            fadeCanvas.gameObject.SetActive(false);
        }

        if (continueMessage != null)
            continueMessage.SetActive(false);

        StartCoroutine(MoveCameraSequence());
    }

    void Update()
    {
        // Espera que el jugador presione Enter cuando ya pueda continuar
        if (canContinue && Input.GetKeyDown(KeyCode.Return))
        {
            sceneManager.LoadScene(nextSceneName);
        }
    }

    IEnumerator MoveCameraSequence()
    {
        // Movimiento de cámara por los puntos
        for (int i = 0; i < camPoints.Length; i++)
        {
            Transform target = camPoints[i];

            while (Vector3.Distance(mainCamera.position, target.position) > 0.05f)
            {
                mainCamera.position = Vector3.Lerp(mainCamera.position, target.position, Time.deltaTime * moveSpeed);
                mainCamera.rotation = Quaternion.Slerp(mainCamera.rotation, target.rotation, Time.deltaTime * moveSpeed);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }

        // Fade out al terminar
        if (fadeCanvas != null)
        {
            fadeCanvas.gameObject.SetActive(true);
            yield return StartCoroutine(FadeOut());
        }

        // Mostrar el mensaje al jugador
        if (continueMessage != null)
            continueMessage.SetActive(true);

        // Activar la posibilidad de continuar
        canContinue = true;
    }

    IEnumerator FadeOut()
    {
        fadeCanvas.alpha = 0;

        while (fadeCanvas.alpha < 1)
        {
            fadeCanvas.alpha += Time.deltaTime;
            yield return null;
        }
    }
}






