using UnityEngine;
using System.Collections;

public class UIMain : TransferDisplay.UserInterface {

    #region Public Styling Variables
    //Style//Text//
    public Font mainFont;
    public int mainFontSize;
    public Color32 mainFontColor = Color.white;
    
    
    //Style//Positioning//
    public float xPadding;
    public float yPadding;

    public enum DisplayPosition
    {
        botLeft,
        topLeft,
        botRight,
        topRight
    };
    public DisplayPosition Position;

    //Style//LineLengths
    public float timeBetweenLetters = .1f;
    public float punctuationTimeModifier;
    public int maxLineLength;
    public int maxChunkLength;

    //Content//
    [HideInInspector]
    public string entityTextName;
    [HideInInspector]
    public string entityTextContent;

    #endregion

    #region Private Variables

    #endregion

    #region Main Methods

    #endregion

    #region Utility Methods

    #endregion
}
