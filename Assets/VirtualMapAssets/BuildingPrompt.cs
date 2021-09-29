using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPrompt : MonoBehaviour
{
    public GameObject PromptCanvas;
    public GameObject PromptButton;
    Button myPromptButton;
    public GameObject InfoPanel;
    public GameObject CloseButton;
    Button myCloseButton;


    private void OnEnable()
    {
        myPromptButton = PromptButton.GetComponent<Button>();
        myPromptButton.onClick.AddListener(OpenInfo);

        myCloseButton = CloseButton.GetComponent<Button>();
        myCloseButton.onClick.AddListener(CloseInfo);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PromptCanvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        PromptCanvas.SetActive(false);
    }

    void OpenInfo()
    {
        InfoPanel.SetActive(true);
    }
    void CloseInfo()
    {
        InfoPanel.SetActive(false);
        PromptCanvas.SetActive(false);
    }
}
