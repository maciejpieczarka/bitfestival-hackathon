using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutPanel : MonoBehaviour
{
    public Image panelImage; // Referencja do komponentu Image panelu
    public float fadeDuration = 3f; // Czas trwania przejœcia w sekundach

    private void Start()
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
        Debug.Log("Fade-out transition complete!");
        // W³asna logika po zakoñczeniu przejœcia
    }
}
