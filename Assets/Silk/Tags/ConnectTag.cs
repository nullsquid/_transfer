using UnityEngine;
using System.Collections;
using System.Linq;
using Silk;
public class ConnectTag : SilkTagBase {

    public string ConnectTarget
    {
        get
        {
            Debug.Log("id is " + _silkTagArgs[0].TrimStart('"').TrimEnd('"'));
            return _silkTagArgs[0].TrimStart('"').TrimEnd('"');
            
        }
    }
	//public 
    public ConnectTag(string tagName, string[] args)
    {
        _tagName = tagName;
        DefineArguments(args);

    }

    

    
}
