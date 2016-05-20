using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 100, 20), "Zoom +"))
		{
			Debug.Log("zoom in");
		}
		if (GUI.Button(new Rect(10, 40, 100, 20), "Zoom -"))
		{
			Debug.Log("zoom out");
		}
	}
}
