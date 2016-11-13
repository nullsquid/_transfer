using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;

namespace Transfer.System
{
    public class DialogueTreeTraversalController : MonoBehaviour
    {
        ConvTree _curTree;
        ConvTree _nextTree;
        ConvTree _startTree;
        //
        ConvNode _curNode;
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
        
        
        #endregion

		#region Initialization Methods
		public void InitializeTree(){
			GetStartTree ();
			GetStartNode ();
			GetNextNodes ();
		}
		#endregion

        #region Main Methods



        void GetStartTree()
        {
            string startTreeName;
            startTreeName = "9" + CharacterDatabase.GetPlayerID() + "_Tree";
            foreach(Transform child in transform)
            {
                if(child.name == startTreeName)
                {
                    _startTree = child.GetComponent<ConvTree>();
                    Debug.Log(_startTree + " " + startTreeName);
                }
            }
            if(_curTree == null)
            {
                _curTree = _startTree;
            }
        }

        void GetStartNode()
        {
            _curNode = _curTree.GetComponent<Transform>().GetChild(0).GetComponent<ConvNode>();
            Debug.Log(_curNode);
        }

        void GetNextNodes()
        {
            foreach(Transform child in _curNode.GetComponent<Transform>())
            {
                nextNodes.Add(child.GetComponent<ConvNode>());
            }
        }

        public void GetNextTree(int index)
        {
            if (_curNode.outLinkedTrees.Count > 0)
            {
                _nextTree = _curNode.outLinkedTrees[index];
            }
        }

        public void TraverseToNextNode(int index)
        {
            if(_curNode.children.Count > 0)
            {
                _curNode = nextNodes[index];
                GetNextNodes();
            }
            else if(_curNode.children.Count == 0 && _curNode.outLinkedTrees.Count > 0)
            {
                GetNextTree(index);
                _curTree = _nextTree;
                _curNode = _curTree.branches[0].GetComponent<ConvNode>();
            }
            else
            {
                throw new NotImplementedException();
            }
        }



        public void GetSpeaker()
        {
            string speaker;
            speaker = _curNode.characterTalking;
            CharacterDatabase.GetCharacterName(speaker);
        }

		public string GetPrompt(){
			return _curNode.prompt;
		}

        public bool GetVisitedState()
        {
            return _curNode.hasVisited;
        }

        public void SetHasVisited()
        {
            _curNode.hasVisited = true;
        }
		/*public string GetResponses(){
			
		}*/

        #endregion

    }
}
