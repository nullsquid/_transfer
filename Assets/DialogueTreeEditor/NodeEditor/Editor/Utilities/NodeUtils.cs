using UnityEngine;
using UnityEditor;
using System.Collections;

public static class NodeUtils {

	public static void CreateNewGraph(string wantedName) {
        NodeGraph curGraph = (NodeGraph)ScriptableObject.CreateInstance<NodeGraph>();
        if (curGraph != null) {
            curGraph.graphName = wantedName;
            curGraph.InitGraph();
            AssetDatabase.CreateAsset(curGraph, "Assets/NodeEditor/Database/" + wantedName + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            NodeEditorWindow curWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
            if(curWindow != null) {
                curWindow.curGraph = curGraph;
            }
        }
        else {
            EditorUtility.DisplayDialog("Node Message", "Unable to create new graph, please see your friendly programmer", "OK");
        }
    }
    public static void LoadGraph() {
        NodeGraph curGraph = null;
        string graphPath = EditorUtility.OpenFilePanel("Load Graph", Application.dataPath + "/NodeEditor/Database", "");
        int appPathLength = Application.dataPath.Length;
        string finalPath = graphPath.Substring(appPathLength - 6);
        curGraph = (NodeGraph)AssetDatabase.LoadAssetAtPath(finalPath, typeof(NodeGraph));
        if(curGraph != null) {
            NodeEditorWindow curWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
            if (curWindow != null) {
                curWindow.curGraph = curGraph;
            }
        }
        else {
            EditorUtility.DisplayDialog("Node Message","Unable to load selected graph", "OK");
        }
        Debug.Log(graphPath);
    }
    public static void UnloadGraph() {
        NodeEditorWindow curWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
        if(curWindow != null) {
            curWindow.curGraph = null;
        }
    }

    public static void CreateNode(NodeGraph curGraph, NodeType nodeType, Vector2 mousePos) {
        if(curGraph != null) {
            NodeBase curNode = null;

            //this will have to be added to for other implementations
            switch (nodeType) {
                case NodeType.Float:
                    curNode = (FloatNode)ScriptableObject.CreateInstance<FloatNode>();
                    curNode.nodeName = "Float Node";
                    break;
                case NodeType.Add:
                    curNode = (AddNode)ScriptableObject.CreateInstance<AddNode>();
                    curNode.nodeName = "Add Node";
                    break;
                default:
                    break;
            }
            if(curNode != null) {
                curNode.InitNode();
                curNode.nodeRect.x = mousePos.x;
                curNode.nodeRect.y = mousePos.y;
                curNode.parentGraph = curGraph;
                curGraph.nodes.Add(curNode);

                AssetDatabase.AddObjectToAsset(curNode, curGraph);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }

    public static void DeleteNode(int nodeID, NodeGraph curGraph) {
        if(curGraph != null) {
            if(curGraph.nodes.Count >= nodeID) {
                NodeBase deleteNode = curGraph.nodes[nodeID];
                if (deleteNode != null) {
                    curGraph.nodes.RemoveAt(nodeID);
                    GameObject.DestroyImmediate(deleteNode, true);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
        }
    }

    public static void DrawGrid(Rect viewRect, float gridSpacing, float gridOpacity, Color gridColor) {
        int widthDivs = Mathf.CeilToInt(viewRect.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(viewRect.height / gridSpacing);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);
        for(int x = 0; x < widthDivs; x++) {
            Handles.DrawLine(new Vector3(gridSpacing * x, 0f, 0f), new Vector3(gridSpacing * x, viewRect.height, 0f));
        }
        for (int y = 0; y < heightDivs; y++) {
            Handles.DrawLine(new Vector3(0f, gridSpacing * y, 0f), new Vector3(viewRect.width, gridSpacing * y, 0f));
        }
        Handles.color = Color.white;
        Handles.EndGUI();

    }
}
