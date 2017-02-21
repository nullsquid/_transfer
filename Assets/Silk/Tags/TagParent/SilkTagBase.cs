using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Silk
{
    public abstract class SilkTagBase
    {
        protected string _tagName;
        List<string> _silkTagArgs = new List<string>();


        public string TagName
        {
            get
            {
                return _tagName;
            }
        }
        public virtual void SilkTagDefinition()
        {

        }

        protected void RunTag(List<string> args)
        {

        }

        protected void SetName(string name)
        {
            _tagName = name;
        }

        protected void DefineArgument(string arg)
        {
            _silkTagArgs.Add(arg);
        }

        protected void DefineArguments(string[] args)
        {
            _silkTagArgs = args.ToList<string>();
        }

    }
}
