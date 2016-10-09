using UnityEngine;
using System.Collections;

namespace TransferDisplay
{
    public class TextRenderer : MonoBehaviour
    {
        #region Pulbic Variables
        //Descriptor variables
        public string entityName;

        //Varibles that will change over time
        public string entityText;
        public string typewriterText;

        //System Variables
        public float timeBetweenLetters = .1f;
        public int wordsPerLine;
        public float xPadding = 100f;
        public float yPadding = 100f;
        public Font mainFont;
        public int fontSize;
        public Color32 mainTextColor = Color.white;
        #endregion

        #region Private Variables
        GUIStyle style;
        private int wordsInLine;
        #endregion

        void Start()
        {
            style = new GUIStyle();
            PrintText(entityText, timeBetweenLetters);

        }

        void OnGUI()
        {
            style.font = mainFont;
            style.fontSize = fontSize;
            style.normal.textColor = mainTextColor;

            GUI.Label(new Rect(xPadding, yPadding, 500, 30),typewriterText.ToUpper(), style);
        }

        IEnumerator IterateThroughCharactersToPrint(string text, float time)
        {

                for (int i = 0; i < text.Length; i++)
                {
                    if(i > 0 && text[i - 1] == ' ')
                    {
                        
                        wordsInLine++;
                        
                        if (wordsInLine > wordsPerLine)
                        {
							
                            typewriterText += "\n";
                            typewriterText.Remove(i - 1, 1);
                            wordsInLine = 0;
                        }
                }
					
                    typewriterText += text[i];
					yield return new WaitForSeconds(time);

            }
        }

        public void PrintText(string newText, float time)
        {
            StartCoroutine(IterateThroughCharactersToPrint(newText, time));
        }


    }
}
