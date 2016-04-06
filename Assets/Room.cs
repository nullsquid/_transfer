using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Room : MonoBehaviour {

    private string _name;
    private int _identitfier;

    public string RoomName {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }
    public int Indentifier {
        get {
            return _identitfier;
        }
        set {
            _identitfier = value;
        }
    }
    public List<Character> charactersInRoom;
    public List<Item> itemsInRoom;
    public List<ExpansionNode> expansionsInRoom;
    
}
