using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TransferDisplay
{
    public class TextRenderer
    {

        #region Public Variables



        //System Variables
        [HideInInspector]
        public string typewriterText;
        public string singleWordText;



        //Style Reference
        [HideInInspector]
        public GUIStyle style;
        #endregion

        #region Private Variables


        private int wordsInLine;
        private int linesInChunk;
        #endregion
        
        #region Constructor
        public TextRenderer(Font newFont, int newFontSize, Color32 newFontColor)
        {
            style = new GUIStyle();
            style.font = newFont;
            style.fontSize = newFontSize;
            style.normal.textColor = newFontColor;
        }
        #endregion

        #region Main Methods

        
        public IEnumerator IterateThroughWordToPrint(string text, int lineLength, int chunkLength, float time)
        {
            string currentWord = "";
            for(int i = 0; i < text.Length; i++)
            {
                currentWord += text[i];
                Debug.Log(currentWord);
                
                if (i > 0 && text[i] == ' ')
                {
                    singleWordText += currentWord;
                    currentWord = "";
                    wordsInLine++;
                    if (wordsInLine >= lineLength)
                    {
                        singleWordText += "\n";
                        linesInChunk++;
                        wordsInLine = 0;
                    }
                }
                if(linesInChunk >= chunkLength)
                {
                    break;
                }
                
                
                
                typewriterText = singleWordText;
                yield return new WaitForSeconds(time);
            }
        }

        public IEnumerator IterateThroughCharactersToPrint(string text, int lineLength, int chunkLength, float time, float punctTime)
        {
            float normalTime = time;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '.')
                    {
                        time += punctTime/Random.Range(1, 1.5f);
                    }
                    else if (text[i] == ',')
                    {
                        time += punctTime / Random.Range(2.5f, 4f);
                    }
                    else
                    {
                        time = normalTime;
                    }

                    if(i > 0 && text[i - 1] == ' ')
                    {
                        
                        wordsInLine++;
                        
                        if (wordsInLine >= lineLength)
                        {
                            linesInChunk++;
                            typewriterText += "\n";
                            typewriterText.Remove(i - 1, 1);
                            wordsInLine = 0;

                            if(linesInChunk >= chunkLength)
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
