using UnityEngine;
using System.Collections;

namespace TransferDisplay
{
    public abstract class UserInterface : MonoBehaviour
    {

        private TextMesh displayText;
        public bool use3dText;
        protected TextRenderer display;
        #region Public Style Variables        
        //Style//Text//
        public Font mainFont;
        [Range(0, 50)]
        public int mainFontSize;
        public Color32 mainFontColor = Color.white;


        //Style//Positioning//
        [Range(0, 500)]
        public float xPadding;
        [Range(0, 500)]
        public float yPadding;
        public enum DisplayPosition
        {
            botLeft,
            topLeft,
            botRight,
            topRight,
            center
        };
        public enum PrintType
        {
            character,
            word,
            line
        }
        public DisplayPosition Position = DisplayPosition.topLeft;
        #endregion

        #region Public System Variables
        //Style//LineLengths
        //[Range()]


        #endregion

        
        #region Private Style Variables
        protected float xPos;
        protected float yPos;
        #endregion

        //might want to make this into a facade
        //the display variable in this class might be better only in children classes

        protected void InitializeUserInterface()
        {
            
            if (display == null)
            {
                display = new TextRenderer(mainFont, mainFontSize, mainFontColor);
            }
            PositionUI();

            
        }

        public virtual void PositionUI()
        {
            switch (Position)
            {

                case DisplayPosition.botLeft:
                    xPos = 0 + xPadding;
                    yPos = Screen.height - yPadding;
                    break;

                case DisplayPosition.botRight:
                    xPos = Screen.width - xPadding;
                    yPos = Screen.height - yPadding;
                    break;

                case DisplayPosition.topLeft:
                    xPos = 0 + xPadding;
                    yPos = 0 + yPadding;
                    break;

                case DisplayPosition.topRight:
                    xPos = Screen.width - xPadding;
                    yPos = 0 + yPadding;
                    break;

                case DisplayPosition.center:
                    xPos = Screen.width / 2;
                    yPos = Screen.height / 2;
                    break;
            }
        }
        
        public virtual void PrintText(string newText, int lineLength, int chunkLength, float time, float punctTimeMod, PrintType type)
        {
            
        }

        

        protected virtual void PrintToScreen()
        {
            if (display.typewriterText != null)
            {
                if (use3dText)
                {
                    displayText = GetComponent<TextMesh>();
                    displayText.font = mainFont;
                    displayText.color = mainFontColor;
                    displayText.fontSize = mainFontSize;
                    displayText.text = display.typewriterText;
                }

                else {
                    GUI.Label(new Rect(xPos, yPos, 500, 30), display.typewriterText.ToUpper(), display.style);
                }
            }
        }

        protected virtual void PrintLineToScreen()
        {

        }

        public virtual void LoadNextChunk()
        {

        }
        

    }
}
