using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {

    public TextMesh commandText;

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.keyDown)
        {

            AddText(e);
            //RemoveText(e);
            
            
            Debug.Log(commandText.text);

        }
        

    }
    void AddText(Event e)
    {
        if (e.keyCode != KeyCode.None)
        {
            if (e.keyCode != KeyCode.Space || e.keyCode != KeyCode.Backspace)
            {
                //get only alphabetical characters
                commandText.text += e.keyCode;

            }
            else if (e.keyCode == KeyCode.Space)
            {
                commandText.text += " ";
            }
        }
    }

    void RemoveText(Event e)
    {
        if(e.keyCode == KeyCode.Backspace)
        {
            
        }
    }
}
