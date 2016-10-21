using UnityEngine;
using System.Collections;
using TransferDisplay;
using TransferInput;
public class UIMainInput :  UserInterface{
    [HideInInspector]
    private string initText = "$>>";
    public string newText = "";
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
        Event e = Event.current;
        if (inputDisplay == null)
        {
            
            inputDisplay = new TextRenderer(mainFont, mainFontSize, mainFontColor);
            
        }
        if (input == null)
        {
            input = new InputController();
        }
        Debug.Log("test 2 " + input.ReturnText);

        if (e.type == EventType.keyDown)
        {
            input.UpdateInput(e);

        }
        newText = input.GetInputText();
        GUI.Label(new Rect(xPos, yPos, 500, 30), initText + newText, inputDisplay.style);

    }

    public string GetNewText()
    {
        return newText;
    }
}
