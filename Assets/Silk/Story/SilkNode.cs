using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Silk
{
    public class SilkNode
    {
        #region Constructor
        /*
        public SilkNode(string name, string passage)
        {
            nodeName = name;
            nodePassage = passage;
        }
        */
        #endregion

        #region Data
        public string nodeName;
        public string nodePassage;
        public Dictionary<string, string> links = new Dictionary<string, string>();
        public Dictionary<string, string[]> tags = new Dictionary<string, string[]>();
        public List<SilkLink> silkLinks = new List<SilkLink>();
        public List<SilkTagBase> silkTags = new List<SilkTagBase>();
        bool _hasVisited = false;
        #endregion

        #region Accessor Methods
        public bool HasVisited
        {
            get
            {
                return _hasVisited;
            }
            set
            {
                _hasVisited = value;
            }
        }
        public void AddLinkName(string linkText, string linkPointer)
        {
            links.Add(linkText, linkPointer);
        }

        public string GetLinkNameValue(string linkText)
        {
            foreach(KeyValuePair<string, string> linkName in links)
            {
                if(linkName.Key == linkText)
                {
                    return linkName.Value;
                }
                
            }
            return null;
        }

        public SilkLink[] GetLinks()
        {
            return silkLinks.ToArray();
        }

        public Dictionary<string, string> Links
        {
            get
            {
                return links;
            }
        }

        public string NodePassage
        {
            get
            {
                return nodePassage;
            }
        }
        #endregion

        #region Data Manipulation Methods

        #endregion





    }
}
