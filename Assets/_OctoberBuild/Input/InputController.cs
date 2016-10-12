using UnityEngine;
using System.Collections;
namespace TransferInput
{
    public class InputController
    {
        public string UpdateInput(Event e)
        {
            Debug.Log(e);
            return e.ToString();
        }
        
    }
}
