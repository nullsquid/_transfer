using UnityEngine;
using System.Collections;
using Transfer.Display;
public class UIMain : Transfer.Display.UserInterface {

    #region Public Styling Variables

    public bool useDummyText;
    //Content//
    [HideInInspector]
    public string entityTextName;
    private static string textContent;
    
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
    public static void SetTextContent(string newContent)
    {
        textContent = newContent;
    }

    public void PrintTextTrigger()
    {
        PrintText(textContent, maxLineLength, maxChunkLength, timeBetweenLetters, punctuationTimeModifier, PrintType);

    }
    #endregion

    #region Utility Methods

    #endregion

    #region Unity Callbacks
    void OnEnable()
    {
        Transfer.System.EventManager.StartListening("TriggerPrint", PrintTextTrigger);
        Transfer.System.EventManager.StartListening("TriggerClear", ClearScreen);
    }

    void OnDisable()
    {
        Transfer.System.EventManager.StopListening("TriggerPrint", PrintTextTrigger);
        Transfer.System.EventManager.StopListening("TriggerClear", ClearScreen);
    }
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
        Debug.Log(textContent);
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
