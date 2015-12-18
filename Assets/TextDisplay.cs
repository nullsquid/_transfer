using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {

    public TextMesh commandText;

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.keyDown)
        {

            ChangeText(e);
            //RemoveText(e);
            
            
            Debug.Log(commandText.text);

        }
        

    }
    void ChangeText(Event e)
    {
        if (e.keyCode != KeyCode.None)
        {
            if (e.keyCode != KeyCode.Space && e.keyCode != KeyCode.Backspace)
            {
                if(e.keyCode >= KeyCode.A && e.keyCode <= KeyCode.Z)
                //get only alphabetical characters
                commandText.text += e.keyCode;

            }
            else if (e.keyCode == KeyCode.Space)
            {
                commandText.text += " ";
            }
            else if (e.keyCode == KeyCode.Backspace)
            {
                RemoveText(e);
            }
        }
    }

    void RemoveText(Event e)
    {
        if(e.keyCode == KeyCode.Backspace)
        {
            if (commandText.text.Length > 0)
            {
                commandText.text = commandText.text.Remove(commandText.text.Length - 1);
            }
        }
    }
}
