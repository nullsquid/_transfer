using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	#region private setup variables
	private string _name;
	private string _id;
	private string _gender;
	private string _pronoun;
	private bool _isPlayer;
	#endregion

	#region alterable variables
	private float _dispositionTowardsPlayer;
	private bool _hasMetPlayer;
	//public Dictionary<string, Character> KnownCharacters = new Dictionary<string, Character>();
	#endregion

	#region public properties
	public string Name{
		get{
			return _name;
		}

		set{
			_name = value;
		}
	}

	public string ID{
		get {
			return _id;
		}

		set{
			_id = value;
		}
	}

	public string Gender{
		get{
			return _gender;
		}

		set{
			_gender = value;
		}
	}

	public string Pronoun{
		get{
			return _pronoun;
		}

		set{
			_pronoun = value;
		}
	}

	public bool IsPlayer{
		get{
			return _isPlayer;
		}
		set{
			_isPlayer = value;
		}
	}

	public float DispositionTowardsPlayer{
		get{
			return _dispositionTowardsPlayer;
		}

		set{
			if(IsPlayer != true){
				_dispositionTowardsPlayer = value;
			}
			else{
				//_dispositionTowardsPlayer = null;
			}
		}
	}

	public bool HasMetPlayer{
		get{
			return _hasMetPlayer;
		}
		set{
			if(IsPlayer != true){
				_hasMetPlayer = value;
			}
			else{
				//_hasMetPlayer = null;
			}
		}
	}
	#endregion
	



	/*
	void Connect(){
		Debug.Log(_name + " is connected with player");
	}
	*/
}
