using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string dialogue;
    public float speed = 0.05f;

    private Coroutine typingCoroutine;
    private bool isTyping = false;

    void Start()
    {
        typingCoroutine = StartCoroutine(TypeText());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogue;
                isTyping = false;
            }
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(speed);
        }

        isTyping = false;
    }
}
