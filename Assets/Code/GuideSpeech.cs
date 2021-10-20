using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideSpeech : MonoBehaviour
{
    public Text messageText;
    public Button screenTapButton;
    private TextWriter.TextWriterSingle textWriterSingle;
    private int clickCount;
    [SerializeField]
    public string startingMessage;
    public List<string> messageList = new List<string>();


    private void Start()
    {
        clickCount = 0;
        screenTapButton.onClick.AddListener(nextLine);
        textWriterSingle = TextWriter.AddWriter_Static(messageText, startingMessage, .02f, true, true, null);
    }

    private void nextLine()
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            // Currently active TextWriter
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            if (clickCount <= messageList.Count)
            {
                string message = messageList[clickCount];
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, null);
                clickCount++;
            }
        }
    }
}
