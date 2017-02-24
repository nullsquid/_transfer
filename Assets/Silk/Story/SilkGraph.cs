using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Silk
{
    public class SilkGraph
    {
        #region Constructor
        //need to find where I get the graph's name
        
        /*public SilkGraph(string name)
        {
            storyName = name;
        }*/

        //transfer specific
        
        
        #endregion

        #region Data
        private string storyName;
        private Dictionary<string, SilkNode> story = new Dictionary<string, SilkNode>();
        public Dictionary<string, SilkNode> Story
        {
            get
            {
                return story;
            }
        }

        //transfer specific
        string connectTargetID;
        string connectTargetName;
        public string ConnectTargetName
        {
            get
            {
                return connectTargetName;
            }
        }

        public string ConnectTargetID
        {
            //for testing
            get
            {
                return connectTargetID;
            }
            set
            {
                connectTargetID = value;
            }
        }

        //HACK decouple this from datastructure?
        public void SetConnectTargetName(string id)
        {
            connectTargetName = Transfer.Data.CharacterDatabase.GetCharacterName(id);
        }
        #endregion

        #region Methods for Manipulating Data
        public void AddToGraph(string nodeName, SilkNode node)
        {
            story.Add(nodeName, node);
        }

        public int NumberOfNodes()
        {
            return story.Count;
        }
        #endregion

        #region Accessor Methods
        public void SetStoryName(string name)
        {
            storyName = name;
        }

        public SilkNode GetNodeByTitle(string nodeName)
        {
            
            SilkNode newSilkNode = new SilkNode();
            
            foreach(KeyValuePair<string, SilkNode> _node in story)
            {
                string modNodeName = storyName + "_" + nodeName;

                StringBuilder newNodeName = new StringBuilder();
                newNodeName.Append(_node.Value.nodeName);
                Debug.Log(modNodeName == newNodeName.ToString());
                //Debug.Log(modNodeName == _node.Value.nodeName);
                if (newNodeName.ToString() == modNodeName.ToString())
                {
                    Debug.Log("hey");
                    newSilkNode = _node.Value;
                    return newSilkNode;
                }
            }
            return null;
        }

        public SilkNode GetNodeByName(string nodeName)
        {
            SilkNode newSilkNode = new SilkNode();
            string newSilkNodeName;
            newSilkNodeName = nodeName.Remove(0, storyName.Length + 1);
            newSilkNode.nodeName = newSilkNodeName;
            newSilkNode.nodePassage = story[nodeName].nodePassage;
            newSilkNode.silkLinks = story[nodeName].silkLinks;
            newSilkNode.silkTags = story[nodeName].silkTags;
            newSilkNode.tags = story[nodeName].tags;
            newSilkNode.links = story[nodeName].links;


            Debug.Log("node name is " + newSilkNode.nodeName);
            return newSilkNode;
            
        }

        public SilkNode GetNodeByRawName(string rawNodeName)
        {
            return story[rawNodeName];
        }

        public SilkNode GetNodeByLink(SilkNode curNode, SilkLink link)
        {
            return link.LinkedNode;
        }

        public SilkNode GetNodeByLinkText(SilkNode curNode, string linkText)
        {
            for(int i = 0; i < curNode.silkLinks.Count; i++)
            {
                if(curNode.silkLinks[i].LinkText == linkText)
                {
                    return curNode.silkLinks[i].LinkedNode;
                }
                
            }
            Debug.LogError("Could not find link text '" + linkText + "'. Did you make a typo?");
            return null;
        }

        public string StoryName
        {
            get
            {
                return storyName;
            }
        }
        
        public string GetNodePassageByTitle(string nodeName)
        {
            string modNodeName = storyName + "_" + nodeName;
            foreach(KeyValuePair<string, SilkNode> _node in story)
            {
                if(_node.Value.nodeName == modNodeName)
                {
                    return _node.Value.nodePassage;
                }
            }
            return null;
        }

        public string GetNodePassage(SilkNode node)
        {
            return node.nodePassage;
        }

        public string GetNodePassage(string nodeName)
        {
            return story[nodeName].nodePassage;
        }

        public string[] GetLinkText(string nodeName)
        {
            SilkNode curNode = story[nodeName];
            string[] linkKeys = curNode.links.Keys.ToArray();
            return linkKeys;
        }

        public string GetRawNodeName(string nodeName)
        { 
            return story[nodeName].nodeName;
        }

        #endregion


    }
}
