using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;
using Silk;
namespace Transfer.System
{
    public class SilkTreeTraversalController : MonoBehaviour
    {

        SilkMotherGraph _trees;

        SilkGraph _startingTree;
        SilkGraph _nextTree;
        SilkGraph _curTree;

        SilkNode _curNode;
        
        

        #region Unity Callbacks
        void Start()
        {
            GetFirstTree();
        }

        void OnEnable()
        {
            //EventManager.StartListening("getFirstTree", GetFirstTree);
        }

        void OnDisable()
        {
            //EventManager.StopListening("getFirstTree", GetFirstTree);
        }
        #endregion


        #region Initialization Methods
        void GetFirstTree()
        {
            string startingTreeName;
            startingTreeName = "9" + CharacterDatabase.GetPlayerID();
            foreach(KeyValuePair<string, SilkGraph> _story in _trees.MotherGraph)
            {
                if(_story.Value.StoryName == startingTreeName)
                {
                    _startingTree = _story.Value;
                }
                
            }
            Debug.Log("first tree is " + startingTreeName);
        }
        
        #endregion


        #region Main Methods
        void TraverseToNextNode(string linkText)
        {
            SilkNode _nextNode = null;
            for(int i = 0; i < _curNode.silkLinks.Count; i++)
            {
                if(_curNode.silkLinks[i].LinkText == linkText)
                {
                    _nextNode = _curNode.silkLinks[i].LinkedNode;
                }
            }
            _curNode = _nextNode;
            _nextNode = null;
        }

        void SetCurrentTree()
        {
            _curTree = _nextTree;
            _nextTree = null;
        }
        //HACK should abstract all tags/put into manager class
        void SetNextTree()
        {
            for(int i = 0; i < _curNode.silkTags.Count; i++)
            {
                if(_curNode.silkTags[i].GetType() == typeof(NextTreeTag))
                {
                    NextTreeTag newNextTreeTag = _curNode.silkTags[i] as NextTreeTag;
                    newNextTreeTag.GetNextTree(_trees);
                }
            }
        }


        #endregion


        #region Utility Methods

        #endregion


    }
}