using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Navigation : MonoBehaviour
{
    Button myButton;                        // The 'Button' component
    public GameObject NavigationTarget;     // The screen this button is meant to navigate to

    void Start()
    {
        myButton = this.GetComponent<Button>();
        myButton.onClick.AddListener(Navigate);     // Waits for a button click
    }

    void Update()
    {
        
    }

    void Navigate()
    {
        CallNewScreen();
        this.transform.parent.gameObject.GetComponent<Screen>().RemoveSelf();   // After making the new screen, it makes the old one remove itself
        this.enabled = false;   // Turns off its own functionality to prevent duplicate functions
    }

    void CallNewScreen()    // This creates the new screen and sets the canvas as its parent
    {
        GameObject newScreen = Instantiate(NavigationTarget, this.transform.parent.parent);
        newScreen.transform.SetParent(this.transform.parent.parent);
    }
}
