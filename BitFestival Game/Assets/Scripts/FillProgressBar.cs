using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FillProgressBar : MonoBehaviour
{
    public Slider mSlider;
    public float decreaseAmount = 5f; // Amount to decrease each interval
    public float decreaseInterval = 0.5f; // Time in seconds between decreases
    public TextMeshProUGUI tmpText;
    public AudioSource audioSource;  // Reference to the existing AudioSource in the scene
    public AudioClip soundClip;
    public GameObject doorToDestroy;

    private EnableMinigames minigamesManager;
    private void Start()
    {
        // Start the repeating function
        InvokeRepeating(nameof(DecreaseValue), decreaseInterval, decreaseInterval);

        minigamesManager = GameObject.Find("Minigames Manager").GetComponent<EnableMinigames>();
    }

    public void IncreaseValue()
    {
        if (mSlider.value >= 98) {
            audioSource.PlayOneShot(soundClip);
            tmpText.text = "Great, you got it!";
            StopDecreasing();
            Destroy(doorToDestroy);
            minigamesManager.OpenFristDoor();
            StartCoroutine(CloseTask());
        }
        else mSlider.value += 5;
    }
    private void DecreaseValue()
    {
        mSlider.value -= decreaseAmount;
        Debug.Log($"Current value: {mSlider.value}");

        if (mSlider.value <= 0f)
        {
            mSlider.value = 0f;
            CancelInvoke(nameof(DecreaseValue));
        }
    }

    public void StopDecreasing()
    {
        CancelInvoke(nameof(DecreaseValue));
        mSlider.value = 100;
    }

    private IEnumerator CloseTask()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
