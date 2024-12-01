using System.Collections; // Dodane
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign the TMP Text component in the Inspector
    private float totalTime = 200f; // 3 minutes in seconds
    private bool twoMinutesCalled = false;
    private bool oneMinuteCalled = false;
    public Canvas canvas;

    public Image panelImage; // Referencja do komponentu Image panelu
    public float fadeDuration = 3f; // Czas trwania przejœcia w sekundach

    public GameObject particle;
    
    void Start()
    {
        if (panelImage != null)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            Debug.LogWarning("Panel Image is not assigned!");
        }

    }

    private IEnumerator FadeOut()
    {
        Color panelColor = panelImage.color; // Pocz¹tkowy kolor panelu
        float startAlpha = panelColor.a;    // Zapamiêtaj pocz¹tkow¹ przezroczystoœæ
        float elapsedTime = 0f;

        // P³ynne przejœcie
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration); // Interpolacja alfa
            panelColor.a = newAlpha; // Ustaw now¹ przezroczystoœæ
            panelImage.color = panelColor; // Przypisz zaktualizowany kolor do panelu
            yield return null;
        }

        // Upewnij siê, ¿e panel jest w pe³ni przeŸroczysty na koñcu
        panelColor.a = 0f;
        panelImage.color = panelColor;

        // Wywo³anie funkcji po zakoñczeniu przejœcia
        endOfTransition();
    }

    private void endOfTransition()
    {
        // Enable the "ComputerStart" child of the canvas
        Transform computerStart = canvas.transform.Find("ComputerStartDialog");
        if (computerStart != null)
        {
            computerStart.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Child object 'ComputerStart' not found in the specified canvas.");
        }
    }
    void Update()
    {
        // Decrement the timer
        totalTime -= Time.deltaTime;

        // Update the UI
        UpdateTimerUI();

        // Check for milestone events
        if (totalTime <= 120f && !twoMinutesCalled)
        {
            twoMinutesCalled = true;
            TwoMinutesLeft();
        }

        if (totalTime <= 60f && !oneMinuteCalled)
        {
            oneMinuteCalled = true;
            OneMinuteLeft();
        }

        // Check if the timer ends
        if (totalTime <= 0f)
        {
            totalTime = 0f; // Clamp to zero
            TimerEnds();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TwoMinutesLeft()
    {
        Debug.Log("Two minutes left!");
        // Add your custom logic here
    }

    private void OneMinuteLeft()
    {
        Debug.Log("One minute left!");
        // Add your custom logic here
    }

    private void TimerEnds()
    {
        Debug.Log("Timer ended!");
        Invoke("RestartLevel", 4f); // Restart level after 4 seconds
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void OnSignalReceived()
    {
        Debug.Log("hhihihi");
        particle.SetActive(true);
    }

}
