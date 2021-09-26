using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public GameObject myCanvas;
    public int DirectionModifier = 1; // Set the direction of the screen animation for forward or back buttons

    void Start()
    {
        Initialization();
    }

    void Update()
    {
        
    }

    void Initialization()   // Set parent as a contingency, set position inside canvas, get REct component, play the entry animation
    {
        if (!this.transform.parent)
            this.transform.SetParent(myCanvas.transform);
        else if (!myCanvas)
            myCanvas = this.transform.parent.gameObject;

        var rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(myCanvas.GetComponent<RectTransform>().rect.width * DirectionModifier, 0);

        Debug.Log(DirectionModifier);

        StartCoroutine("SlideInPlace", rt);
    }

    public void RemoveSelf()    // Play the exit transition and destroy self
    {
        // At some point we'll need to add a function to kill all functionality of all children

        var rt = this.GetComponent<RectTransform>();

        Debug.Log(DirectionModifier);

        StartCoroutine("Removal", rt);
    }

    private IEnumerator SlideInPlace(RectTransform rt)  // This plays the sliding in animation
    {
        bool isDone = false;

        while (!isDone)
        {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, new Vector2(0, 0), 4f * Time.deltaTime);
            isDone = (Mathf.Abs(rt.anchoredPosition.x) <= 0.01f) ? true : false;
            yield return null;
        }

        yield return null;
    }

    private IEnumerator Removal(RectTransform rt)   // This plays the sliding out animation and then destroys itself
    {
        bool isDone = false;
        float target = -myCanvas.GetComponent<RectTransform>().rect.width;

        while (!isDone)
        {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, new Vector2((target - 10f) * DirectionModifier, 0), 4f * Time.deltaTime);
            isDone = (Mathf.Abs(rt.anchoredPosition.x) >= Mathf.Abs(target)) ? true : false;

            yield return null;
        }

        Destroy(this.gameObject);

        yield return null;
    }
}
