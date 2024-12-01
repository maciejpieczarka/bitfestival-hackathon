using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutPanel : MonoBehaviour
{
    public Image panelImage; // Referencja do komponentu Image panelu
    public float fadeDuration = 3f; // Czas trwania przej�cia w sekundach

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
        Color panelColor = panelImage.color; // Pocz�tkowy kolor panelu
        float startAlpha = panelColor.a;    // Zapami�taj pocz�tkow� przezroczysto��
        float elapsedTime = 0f;

        // P�ynne przej�cie
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration); // Interpolacja alfa
            panelColor.a = newAlpha; // Ustaw now� przezroczysto��
            panelImage.color = panelColor; // Przypisz zaktualizowany kolor do panelu
            yield return null;
        }

        // Upewnij si�, �e panel jest w pe�ni prze�roczysty na ko�cu
        panelColor.a = 0f;
        panelImage.color = panelColor;

        // Wywo�anie funkcji po zako�czeniu przej�cia
        endOfTransition();
    }

    private void endOfTransition()
    {
        Debug.Log("Fade-out transition complete!");
        // W�asna logika po zako�czeniu przej�cia
    }
}
