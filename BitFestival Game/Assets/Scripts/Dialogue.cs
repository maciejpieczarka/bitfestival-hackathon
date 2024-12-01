using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public AudioClip[] audioClips; // Array of audio clips for each line
    public float textSpeed;

    private int index;
    public AudioSource audioSource; // AudioSource component

    public delegate void SignalAction();
    public static event SignalAction pokazParticle;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        PlayAudio(); // Play audio for the first line
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            PlayAudio(); // Play the next audio clip
            StartCoroutine(TypeLine());
        }
        else
        {
            BroadcastMessage("OnSignalReceived", SendMessageOptions.DontRequireReceiver);
            gameObject.SetActive(false);
        }
    }

    void PlayAudio()
    {
        Debug.Log("Play audio");
        //if (audioClips != null && index < audioClips.Length && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }
}
