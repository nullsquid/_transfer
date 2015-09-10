using UnityEngine;
using System.Collections;

public class NonPlayerCharacter : Character, IEncounterable {
    private bool _haveEncounteredPlayer = false;
    //TODO add event to trigger this from the player character class
    public bool HaveEncounteredPlayer
    {
        get
        {
            return _haveEncounteredPlayer;
        }

        set
        {
            _haveEncounteredPlayer = value;
        }
    }
	public Character AddToplayerMemory(){
        if (HaveEncounteredPlayer == false)
        {
            return this;
        }
        else
        {
            return null;
        }
        
	}

}
