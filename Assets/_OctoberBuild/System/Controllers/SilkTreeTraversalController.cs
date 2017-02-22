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

        //HACK Need to figure out a better way to get the parser's data into this class
        Parser _parser;
        

        #region Unity Callbacks
        //TODO Get Start method out of this class and into an initialization class
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
            _parser = GameObject.Find("Silk").GetComponent<Parser>();
            //_startingTree = new SilkGraph();

            string startingTreeName;
            startingTreeName = "9" + CharacterDatabase.GetPlayerID();
            foreach(KeyValuePair<string, SilkGraph> _story in _parser.mother.MotherGraph)
            {
                //Debug.Log(_story);
                if(_story.Key == startingTreeName)
                {
                    _startingTree = _story.Value;
                    Debug.Log("hey");
                }
                foreach (KeyValuePair<string, SilkNode> _node in _story.Value.Story)
                {
                    Debug.Log("node name is " + TrimTreenameOffNode(_node.Value, _startingTree.StoryName).nodeName);
                }
            }
            
            Debug.Log(_startingTree.GetNodeByName("Start").nodePassage);

        }
        
        //TODO argument out of range exception
        SilkNode TrimTreenameOffNode(SilkNode _rawNode, string _rawTreeName)
        {
            SilkNode newSilkNode = _rawNode;
            newSilkNode.nodeName = _rawNode.nodeName.Remove(0, (_rawTreeName.Length) + 1);
            return newSilkNode;

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