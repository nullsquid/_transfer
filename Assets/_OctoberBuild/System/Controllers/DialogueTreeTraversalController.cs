using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;

namespace Transfer.System
{
    public class DialogueTreeTraversalController : MonoBehaviour
    {
        ConvTree curTree;
        ConvTree nextTree;
        //
        ConvNode curNode;
        List<ConvNode> nextNodes = new List<ConvNode>();
        #region Unity Callbacks
        void OnEnable()
        {
            EventManager.StartListening("getStartTree", GetStartTree);
        }
        void OnDisable()
        {
            EventManager.StartListening("getStartTree", GetStartTree);
        }
        
        void Start()
        {
            
        }
        #endregion

        #region Main Methods
        void GetStartTree()
        {
            ConvTree startTree;
            string startTreeName;
            startTreeName = "9" + CharacterDatabase.GetPlayerID() + "_Tree";
            foreach(Transform child in transform)
            {
                if(child.name == startTreeName)
                {
                    startTree = child.GetComponent<ConvTree>();
                    Debug.Log(startTree + " " + startTreeName);
                }
            }
        }

        void GetStartNode()
        {
            curNode = curTree.GetComponent<Transform>().GetChild(0).GetComponent<ConvNode>();
            Debug.Log(curNode);
        }

        void GetNextNodes()
        {
            foreach(Transform child in curNode.GetComponent<Transform>())
            {
                nextNodes.Add(child.GetComponent<ConvNode>());
            }
        }

        public void GetNextTree(int index)
        {
            if (curNode.outLinkedTrees.Count > 0)
            {
                nextTree = curNode.outLinkedTrees[index];
            }
        }

        public void TraverseToNextNode(int index)
        {
            if(curNode.children.Count > 0)
            {
                curNode = nextNodes[index];
                GetNextNodes();
            }
            else if(curNode.children.Count == 0 && curNode.outLinkedTrees.Count > 0)
            {
                GetNextTree(index);
                curTree = nextTree;
                curNode = curTree.branches[0].GetComponent<ConvNode>();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        

        public void GetSpeaker()
        {
            string speaker;
            speaker = curNode.characterTalking;
            CharacterDatabase.GetCharacterName(speaker);
        }

        


        #endregion

    }
}
