using UnityEngine;
using System.Collections;
using TransferDisplay;
using TransferInput;
public class UIMainInput :  UserInterface{
    [HideInInspector]
    private string initText = "$>> ";
    private string newText = "";
    TextRenderer inputDisplay;
    InputController input;
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
        //might have to do this slightly differently
        if(input == null)
        {
            input = new InputController();
        }
        
        GUI.Label(new Rect(xPos, yPos, 500, 30), initText, inputDisplay.style);
    }
}
