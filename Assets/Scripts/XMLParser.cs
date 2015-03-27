using UnityEngine;
using System.Collections;
using System.Xml;

public class XMLParser : MonoBehaviour {

	public XmlDocument document = new XmlDocument();
	// Use this for initialization
	void Start () {
		//document.Load("Resources/1A.xml");
		//Resources.Load("1A.xml");
		document.Load("Assets/Resources/1A.xml");
		XmlElement firstChild = (XmlElement)document.DocumentElement.FirstChild;
		print(firstChild);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
