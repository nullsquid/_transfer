using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Silk
{
    public class SilkMotherGraph
    {

        #region Data
        //need to make this string, SilkGraph
        private Dictionary<string, SilkGraph> motherGraph = new Dictionary<string, SilkGraph>();

        public Dictionary<string, SilkGraph> MotherGraph
        {
            get
            {
                return motherGraph;
            }
        }
        #endregion
        
        #region Data Manipulation Methods
        public void AddToMother(string storyName, SilkGraph story)
        {
            motherGraph.Add(storyName, story);
        }
        #endregion
        
        //public void AddToMotherGraph()
        //public loadStory
    }
}
