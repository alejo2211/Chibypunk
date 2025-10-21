using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroCinematic : MonoBehaviour
{
    [Header("Cámara y recorrido")]
    public Transform mainCamera;
    public Transform[] camPoints;
    public float moveSpeed = 2f;
    public float waitTime = 3f;

    [Header("Narrativa")]
    [TextArea(3, 5)]
    public string[] storyLines;           // Líneas del texto narrativo
    public TMP_Text narrativeText;        // Texto principal
    public CanvasGroup fadeCanvas;        // Imagen negra para fade
    public TMP_Text continueText;         // Texto "Presiona ENTER"

    [Header("Audio opcional")]
    public AudioSource backgroundMusic;

    [Header("Escena siguiente")]
    public string nextSceneName = "Nivel1"; // Nombre de la escena a cargar

    private bool playing = false;
    private bool cinematicFinished = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main.transform;

        if (continueText != null)
            continueText.gameObject.SetActive(false);

        StartCoroutine(PlayCinematic());
    }

    void Update()
    {
        // Esperar al jugador al final
        if (cinematicFinished && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator PlayCinematic()
    {
        playing = true;

        yield return StartCoroutine(FadeIn());

        if (backgroundMusic != null)
            backgroundMusic.Play();

        for (int i = 0; i < camPoints.Length; i++)
        {
            yield return StartCoroutine(MoveCameraTo(camPoints[i]));

            if (i < storyLines.Length)
                yield return StartCoroutine(ShowNarrative(storyLines[i]));
        }

        yield return StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1f);

        cinematicFinished = true;
        if (continueText != null)
        {
            continueText.gameObject.SetActive(true);
            StartCoroutine(BlinkContinueText());
        }
    }

    IEnumerator MoveCameraTo(Transform target)
    {
        while (Vector3.Distance(mainCamera.position, target.position) > 0.05f)
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, target.position, Time.deltaTime * moveSpeed);
            mainCamera.rotation = Quaternion.Slerp(mainCamera.rotation, target.rotation, Time.deltaTime * moveSpeed);
            yield return null;
        }
    }

    IEnumerator ShowNarrative(string text)
    {
        narrativeText.text = "";
        narrativeText.alpha = 1;

        foreach (char c in text)
        {
            narrativeText.text += c;
            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(waitTime);

        // Desvanecer texto
        for (float t = 1f; t >= 0; t -= Time.deltaTime)
        {
            narrativeText.alpha = t;
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        fadeCanvas.alpha = 1;
        while (fadeCanvas.alpha > 0)
        {
            fadeCanvas.alpha -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (fadeCanvas.alpha < 1)
        {
            fadeCanvas.alpha += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator BlinkContinueText()
    {
        while (cinematicFinished)
        {
            continueText.alpha = Mathf.PingPong(Time.time * 1.5f, 1);
            yield return null;
        }
    }

    IEnumerator LoadNextScene()
    {
        // Pequeño fade antes de cambiar
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(nextSceneName);
    }
}


