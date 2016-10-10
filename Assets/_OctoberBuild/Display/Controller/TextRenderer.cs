using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TransferDisplay
{
    public class TextRenderer
    {
        #region Public Variables
        //Descriptor variables
        [HideInInspector]
        public string entityName;

        //Varibles that will change over time
        [HideInInspector]
        public string entityText;
        [HideInInspector]
        public string typewriterText;

        //System Variables
        public float timeBetweenLetters = .1f;
        public float punctuationTimeModifier;
        public int maxLineLength;
        public int maxChunkLength;
        public float xPadding = 100f;
        public float yPadding = 100f;
        public Font mainFont;
        public int fontSize;
        public Color32 mainTextColor = Color.white;

        //Style Reference
        [HideInInspector]
        public GUIStyle style;
        #endregion

        #region Private Variables


        private int wordsInLine;
        private int linesInChunk;
        #endregion

        #region Constructor
        public TextRenderer()
        {
            style = new GUIStyle();
        }
        #endregion

        #region Main Methods



        public IEnumerator IterateThroughCharactersToPrint(string text, float time)
        {
            float normalTime = time;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '.')
                    {
                        time += punctuationTimeModifier/Random.Range(1, 1.5f);
                    }
                    else if (text[i] == ',')
                    {
                        time += punctuationTimeModifier / Random.Range(2.5f, 4f);
                    }
                    else
                    {
                        time = normalTime;
                    }

                    if(i > 0 && text[i - 1] == ' ')
                    {
                        
                        wordsInLine++;
                        
                        if (wordsInLine > maxLineLength)
                        {
                            linesInChunk++;
                            typewriterText += "\n";
                            typewriterText.Remove(i - 1, 1);
                            wordsInLine = 0;

                            if(linesInChunk >= maxChunkLength)
                            {
                                //event to call the next chunk
                                break;
                            }
                        }
                }
					
                    typewriterText += text[i];
					yield return new WaitForSeconds(time);

            }
        }
        #endregion

        #region Utility Methods
        /*
        public void PrintText(string newText, float time)
        {
            StartCoroutine(IterateThroughCharactersToPrint(newText, time));
        }*/

        
        #endregion
        
    }

}
