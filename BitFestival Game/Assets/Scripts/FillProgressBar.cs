using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillProgressBar : MonoBehaviour
{
    public Slider mSlider;
    public float decreaseAmount = 5f; // Amount to decrease each interval
    public float decreaseInterval = 0.5f; // Time in seconds between decreases
    private void Start()
    {
        // Start the repeating function
        InvokeRepeating(nameof(DecreaseValue), decreaseInterval, decreaseInterval);
    }

    public void IncreaseValue()
    {
        if (mSlider.value >= 98) { 
            Debug.Log("100%!");
            StopDecreasing();
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
}
