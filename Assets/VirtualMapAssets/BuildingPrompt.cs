using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPrompt : MonoBehaviour
{
    public string buttonText;

    public GameObject myPlayer;
    public GameObject PromptCanvas;
    public GameObject PromptButton;
    Button myPromptButton;
    public GameObject InfoPanel;
    public GameObject CloseButton;
    Button myCloseButton;

    private void Start()
    {
        myPlayer = GameObject.Find("Player");
        PromptButton.GetComponentInChildren<Text>().text = buttonText;
    }

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
        PromptButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        InfoPanel.SetActive(false);
        PromptCanvas.SetActive(false);
        myPlayer.GetComponent<PlayerMovement>().myState = PlayerMovement.PlayerState.Walking;
    }

    void OpenInfo()
    {
        InfoPanel.SetActive(true);
        PromptButton.SetActive(false);

        myPlayer.GetComponent<PlayerMovement>().myState = PlayerMovement.PlayerState.Reading;
    }
    void CloseInfo()
    {
        InfoPanel.SetActive(false);
        PromptButton.SetActive(true);
        //PromptCanvas.SetActive(true);

        myPlayer.GetComponent<PlayerMovement>().myState = PlayerMovement.PlayerState.Walking;
    }
}
