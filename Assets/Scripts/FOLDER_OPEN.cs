using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOLDER_OPEN : MonoBehaviour
{
    [SerializeField] private GameObject OpenButton;
    [SerializeField] private GameObject CloseButton;
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject AcceptButton;
    [SerializeField] private GameObject RejectButton;

    [SerializeField] private List<GameObject> Folders;
    private int currentFolderIndex = 0;

    public void OpenFolder()
    {
        OpenButton.SetActive(false);
        CloseButton.SetActive(true);
        NextButton.SetActive(true);
        AcceptButton.SetActive(true);
        RejectButton.SetActive(true);

        if (Folders.Count > 0)
        {
            Folders[currentFolderIndex].SetActive(true);
        }
    }

    public void CloseFolder()
    {
        OpenButton.SetActive(true);
        CloseButton.SetActive(false);
        NextButton.SetActive(false);
        AcceptButton.SetActive(false);
        RejectButton.SetActive(false);

        foreach (GameObject folder in Folders)
        {
            folder.SetActive(false);
        }
    }

    public void NextFolder()
    {
        Folders[currentFolderIndex].SetActive(false);
        currentFolderIndex = (currentFolderIndex + 1) % Folders.Count;
        Folders[currentFolderIndex].SetActive(true);
    }
}
