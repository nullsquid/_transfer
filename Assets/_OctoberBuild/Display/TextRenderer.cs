using UnityEngine;
using System.Collections;

public class TextRenderer : MonoBehaviour {
    #region Pulbic Variables
    //Descriptor variables
    public string entityName;

    //Varibles that will change over time
    public string entityText;
    public string typewriterText;

    //System Variables
    public float timeBetweenLetters = .1f;
    public float xPadding = 100f;
    public float yPadding = 100f;
    public Font mainFont;
    public int fontSize;
    public Color32 mainTextColor = Color.white;
    #endregion

    #region Private Variables
    GUIStyle style;
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

        GUI.Label(new Rect(xPadding, Screen.height - yPadding, 500, 30), typewriterText.ToUpper(), style);
    }

    IEnumerator TypeWriter(string text, float time)
    {
        while (typewriterText.Length != text.Length)
        {
            for (int i = 0; i < text.Length; i++)
            {
                typewriterText += text[i];
                yield return new WaitForSeconds(time);

            }
        }
    }

    public void PrintText(string newText, float time)
    {
        StartCoroutine(TypeWriter(newText, time));
    }


}
