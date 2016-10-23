using UnityEngine;
using System.Collections;
using Transfer.Display;
using Transfer.Input;
public class UIMainInput :  UserInterface{
	#region Private Data Variables
    private string initText = "$>>";
	[HideInInspector]
    public string newText = "";
	[HideInInspector]
	private string _returnText;
	#endregion

	#region Public Accessors
	public string ReturnText{
		get{
			return _returnText;
		}
	}
	#endregion

	#region Private References
    TextRenderer inputDisplay;
    InputController input;
	#endregion
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

        if (e.type == EventType.keyDown)
        {
            input.UpdateInput(e);

        }
		_returnText = input.ReturnText;
        newText = input.InputText;
        GUI.Label(new Rect(xPos, yPos, 500, 30), initText + newText, inputDisplay.style);

    }
	//make an accessor parameter?
    public string GetNewText()
    {
        return newText;
    }
}
