using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HelpMenu : MonoBehaviour {
    public List<string> helpItems = new List<string>();
    public List<string> formattedHelpItems = new List<string>();
	// Use this for initialization
	void Start () {
	    for(int i = 0; i < helpItems.Count; i++)
        {
            formattedHelpItems.Add(helpItems[i].ToUpper());
        }
	}
}
