using UnityEngine;
using System.Collections;

namespace TransferDisplay
{
    public class UserInterface : MonoBehaviour
    {
        TextRenderer display = new TextRenderer();
      

        void OnGUI()
        {

            //use a facade for all this initialization garbage?
            Debug.Log(display);
            display.style.font = display.mainFont;
            display.style.fontSize = display.fontSize;
            display.style.normal.textColor = display.mainTextColor;

            GUI.Label(new Rect(display.xPadding, display.yPadding, 500, 30), display.typewriterText.ToUpper(), display.style);
        }

    }
}
