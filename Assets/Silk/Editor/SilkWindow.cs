using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Silk.Editor {
    public class SilkWindow : MonoBehaviour {
        [MenuItem("Silk/Create New Silk")]
        private static void CreateNewSilk()
        {
            GameObject newSilkInstance;
            newSilkInstance = new GameObject("Silk");
            newSilkInstance.AddComponent<Parser>();
            newSilkInstance.AddComponent<Importer>();
        }
    }
}
