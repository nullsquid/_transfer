using UnityEngine;
using System.Collections;
using TransferDisplay;
public class UIMainInput :  UserInterface{
    [HideInInspector]
    private string initText = "$>> ";
    TextRenderer inputDisplay;
    //testing
    void Start()
    {
        

        //facade this out
        InitializeUserInterface();

    }

    void OnGUI()
    {
        if (inputDisplay == null)
        {
            
            inputDisplay = new TextRenderer(mainFont, mainFontSize, mainFontColor);
            
        }

        GUI.Label(new Rect(xPos, yPos, 500, 30), initText, inputDisplay.style);
    }
}
