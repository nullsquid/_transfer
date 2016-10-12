using UnityEngine;
using System.Collections;
using TransferDisplay;
public class UIMain : TransferDisplay.UserInterface {

    #region Public Styling Variables

    public bool useDummyText;
    //Content//
    [HideInInspector]
    public string entityTextName;
    [HideInInspector]
    public string textContent;
    [HideInInspector]
    public string dummyTextContent = 
        "Lorem ipsum dolor sit amet, "
        + "consectetur adipiscing elit. "
        + "Vivamus accumsan consectetur "
        + "urna id dignissim. Duis ut "
        + "lectus efficitur, laoreet "
        + "justo et, hendrerit nulla. "
        + "Aenean ultricies molestie lorem "
        + "ac scelerisque. Fusce sollicitudin, "
        + "dui vitae mattis accumsan, leo dolor "
        + "maximus ligula, in auctor magna velit "
        + "at magna. Nulla vitae semper lectus. "
        + "Sed convallis dui ut nibh scelerisque "
        + "ullamcorper. Phasellus at ante et metus "
        + "venenatis congue. Sed sapien erat, dapibus "
        + "quis pellentesque rutrum, lacinia nec enim. "
        + "Nullam vel imperdiet lorem. Sed erat "
        + "eros, fringilla eget convallis et, "
        + "venenatis et mi. Curabitur vulputate "
        + "odio a dictum dapibus.";

    #endregion

    #region Public Display Variables
    public PrintType PrintType;

    [Range(0.0000f, 0.1f)]
    public float timeBetweenLetters;
    [Range(0.0f, 0.5f)]
    public float punctuationTimeModifier;
    [Range(1, 50)]
    public int maxLineLength;
    [Range(1, 50)]
    public int maxChunkLength;
    

    #endregion
    #region Private Variables

    #endregion

    #region Main Methods

    #endregion

    #region Utility Methods

    #endregion

    #region Unity Callbacks
    void Start()
    {

        //none of these should happen in this start method

        if (useDummyText)
        {
            textContent = dummyTextContent;
        }
        //facade this out
        InitializeUserInterface();
        PrintText(textContent, maxLineLength, maxChunkLength, timeBetweenLetters, punctuationTimeModifier, PrintType);
    }

    

    void OnGUI()
    {
        if(display == null)
        {
            display = new TextRenderer(mainFont, mainFontSize, mainFontColor);
        }

        PrintToScreen();
        
    }
    //logic for typewriter effect
    public override void PrintText(string newText, int lineLength, int chunkLength, float time, float punctTimeMod, PrintType type)
    {
        if (type == PrintType.character)
        {
            StartCoroutine(display.IterateThroughCharactersToPrint(newText, lineLength, chunkLength, time, punctTimeMod));
        }
        else if(type == PrintType.word)
        {
            StartCoroutine(display.IterateThroughWordToPrint(newText, lineLength, chunkLength, time));
        }
        else if(type == PrintType.line)
        {
            StartCoroutine(display.IterateThroughLineToPrint(newText, lineLength, chunkLength, time));
        }
    }





    #endregion
}
