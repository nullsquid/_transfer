using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Silk {
    public class Importer : MonoBehaviour
    {
        public TextAsset[] rawTweeFiles;
        // Use this for initialization
        void Awake()
        {
            rawTweeFiles = Resources.LoadAll<TextAsset>("Text");
            
        }
    }
}
