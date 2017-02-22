using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Silk;
public class NextTreeTag :  SilkTagBase{

    public NextTreeTag(string tagName, string[] args)
    {
        DefineArguments(args);
        _tagName = tagName;
    }

    public override void SilkTagDefinition()
    {
        base.SilkTagDefinition();
    }

    public SilkGraph GetNextTree(SilkMotherGraph _trees)
    {
        string _treeName;
        _treeName = _silkTagArgs[0];
        foreach(KeyValuePair<string, SilkGraph> _tree in _trees.MotherGraph)
        {
            if (_trees.MotherGraph.ContainsKey(_treeName))
            {
                if (_tree.Value.StoryName == _treeName)
                {
                    return _tree.Value;
                }
            }

            
        }
        return null;
    }
}
