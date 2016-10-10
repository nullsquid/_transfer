using UnityEngine;
using System.Collections;

namespace TransferDisplay
{
    public abstract class UserInterface : MonoBehaviour
    {
        TextRenderer display;
      
        void Start()
        {
            display = new TextRenderer();
            display.style = new GUIStyle();
        }

        
        void OnGUI()
        {
            /*if(display == null)
            {
                display = new TextRenderer();
            }

            //use a facade for all this initialization garbage?
            Debug.Log(display);
            Debug.Log(display.typewriterText);
            display.style.font = display.mainFont;
            display.style.fontSize = display.fontSize;
            display.style.normal.textColor = display.mainTextColor;
            display.entityText = "Lorem ipsum";
            */

            //GUI.Label(new Rect(display.xPadding, display.yPadding, 500, 30), display.typewriterText.ToUpper(), display.style);
        }



        public void PrintText(string newText, float time)
        {
            StartCoroutine(display.IterateThroughCharactersToPrint(newText, time));
        }

    }
}
