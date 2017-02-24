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

        SilkNode _firstNode;
        SilkNode _curNode;

        //HACK Need to figure out a better way to get the parser's data into this class
        Parser _parser;
        
        public SilkGraph CurTree
        {
            get
            {
                return _curTree;
            }
        }

        public SilkNode CurNode
        {
            get
            {
                return _curNode;
            }
        }
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

                if(_story.Key == startingTreeName)
                {
                    _startingTree = _story.Value;
                    _curTree = _startingTree;
                    //NOTE
                    //need to append onto the node name the tree name because that's how it's recorded
                    //in the story dictionary
                    _firstNode = _curTree.GetNodeByTitle("Start");
                    Debug.Log(_firstNode.nodePassage);
                    
                }
                
                
            }
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