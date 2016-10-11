using UnityEngine;
using System.Collections;
using TransferDisplay;
public class UIMainInput :  UserInterface{
    [HideInInspector]
    private string promptText = "$>> ";
    TextRenderer inputDisplay;
    //testing
    void Start()
    {
        
        Debug.Log(display);
        Debug.Log(promptText);
        InitializeUserInterface();
        
    }

    void OnGUI()
    {
        if (inputDisplay == null)
        {
            inputDisplay = new TextRenderer();
            inputDisplay.style.font = mainFont;
            inputDisplay.style.fontSize = mainFontSize;
            inputDisplay.style.normal.textColor = mainFontColor;
        }
        Debug.Log("input display is " + inputDisplay);

        GUI.Label(new Rect(xPos, yPos, 500, 30), promptText, inputDisplay.style);
    }
}
