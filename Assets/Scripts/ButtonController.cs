using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public List<Button> buttonsToControl;

    void Start()
    {
        SetButtonsInteractable(false); // Disable all buttons at start
    }

    public void SetButtonsInteractable(bool state)
    {
        foreach (Button btn in buttonsToControl)
        {
            btn.interactable = state;
        }
    }
}
