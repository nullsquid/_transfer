using UnityEngine;
using System.Collections;

public class AnimateText : MonoBehaviour {

	public string theText;
	public float textSpeed = 0.1f;
	public float pauseSpeed = 0.2f;

	void Start () {
		StartCoroutine(TextAnimator(theText));
	}
	

	IEnumerator TextAnimator(string strComplete){
		string str = "";
		char curChar;
		int i = 0;

		while (i < strComplete.Length){
			str += strComplete[i++];
			//issue: stops BEFORE the period and does not render it until after the waitforseconds
			curChar = strComplete[i - 1];
			if(curChar == '.'){
				Debug.LogWarning("rendered");
				yield return new WaitForSeconds(pauseSpeed);
			}
			yield return new WaitForSeconds(textSpeed);
			print(str);
		}
	}
}
