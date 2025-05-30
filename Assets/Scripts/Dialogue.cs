using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject dialogueBlocker;
    public TextMeshProUGUI dialogueText;
    public string dialogue;
    public float speed = 0.05f;
    public ButtonController buttonController;

    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private bool hasDialogueFinished = false;

    public void StartTypewriter()
    {
        dialogueBox.SetActive(true);
        dialogueBlocker.SetActive(true);
        hasDialogueFinished = false;

        if (!isTyping)
        {
            typingCoroutine = StartCoroutine(TypeText());
        }
    }

    void Update()
    {
        if (!dialogueBox.activeInHierarchy) return; // Only allow input when dialogue box is shown

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogue;
                isTyping = false;
            }
            else if (!hasDialogueFinished)
            {
                // Dialogue just finished — hide UI and enable buttons
                dialogueBox.SetActive(false);
                dialogueBlocker.SetActive(false);
                hasDialogueFinished = true;

                buttonController.SetButtonsInteractable(true);
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
