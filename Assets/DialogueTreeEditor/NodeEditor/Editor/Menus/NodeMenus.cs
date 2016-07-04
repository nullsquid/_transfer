using UnityEngine;
using UnityEditor;
using System.Collections;

public class NodeMenus {

	[MenuItem("Node Editor/Launch Editor")]

    public static void InitNodeEditor() {
        //Launches node editor
        NodeEditorWindow.InitEditorWindow();
    }
}
