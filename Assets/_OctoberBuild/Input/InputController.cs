using UnityEngine;
using System.Collections;
namespace TransferInput
{
    public class InputController
    {
        private string inputText = "";
        //need to figure out the architecture for how to link all this together
        private string UpdateInput(Event e)
        {
            Debug.Log(e);

            return inputText += e;
        }

        public string PrintInput()
        {
            return UpdateInput(Event.current);
            //public method for getting input onto the screen
        }

        public void ReturnInput()
        {
            //if you press enter this happens
        }
        
    }
}
