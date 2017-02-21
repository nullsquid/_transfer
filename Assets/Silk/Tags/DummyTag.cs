using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Silk;
public class DummyTag : SilkTagBase {

    public DummyTag(string tagName, string[] args)
    {
        DefineArguments(args);
        _tagName = tagName;
    }

    public override void SilkTagDefinition()
    {
        base.SilkTagDefinition();
    }

}
