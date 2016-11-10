using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;

namespace Transfer.System
{
    public class DialogueTreeTraversalController : MonoBehaviour
    {
        ConvTree curTree;
        ConvNode curNode;
        ///
        #region Unity Callbacks
        void OnEnable()
        {

        }
        void OnDisable()
        {

        }

        void Update()
        {

        }
        
        void Start()
        {
            GetStartTree();
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

        public void TraverseToNextNode(int index)
        {

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
