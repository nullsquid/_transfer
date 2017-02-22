using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Silk
{
    public class SilkLink
    {
        
        private SilkNode _backRefNode;
        private SilkNode _linkedNode;
        private string _linkText;

        public SilkNode BackRefNode
        {
            get
            {
                return _backRefNode;
            }

        }

        public SilkNode LinkedNode
        {
            get
            {
                return _linkedNode;
            }

        }

        public string LinkText
        {
            get
            {
                return _linkText;
            }

        }

        #region Constructor
        public SilkLink(SilkNode thisNode, SilkNode linkedNode, string text)
        {
            _backRefNode = thisNode;
            _linkedNode = linkedNode;
            _linkText = text;
        }
        #endregion
    }
}
