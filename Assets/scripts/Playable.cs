using UnityEngine;
using System.Collections;

public class Playable : MonoBehaviour {

	public string playableType;
	public bool isCard = true;

	public GameObject pfPlayable;
	public GameObject parentGroup;

	private GameObject playableObject;
	private SpriteRenderer sr;

	public Vector2 offset = new Vector2(-0.5f, 0.5f);
	public Vector2 drawLoc;
	public bool drawPileLoc = true;

	Vector2 position;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown()
	{
		Debug.Log(transform.name + " clicked.");

		MakePlayable(pfPlayable);
	}

	void MakePlayable(GameObject obj)
	{
		if (drawPileLoc)
		{
			position.x = drawLoc.x;
			position.y = drawLoc.y;
		}
		else
		{
			position.x = transform.position.x + offset.x;
			position.y = transform.position.y + offset.y;
		}

		playableObject = GameObject.Instantiate(obj) as GameObject;

		playableObject.transform.position = position;

		playableObject.transform.parent = parentGroup.transform;

		if (isCard)
		{
			Debug.Log("playable card");
			SpriteRenderer playableSpriteRenderer = playableObject.GetComponent<SpriteRenderer>();
			playableSpriteRenderer.sprite = sr.sprite;

			GameObject title = getChildObject(playableObject, "Title");
			TextMesh titleText = title.GetComponent<TextMesh>();
			titleText.text = playableType;

		}
	}

	//make functions script as include
	GameObject getChildObject(GameObject obj, string findName)
	{
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			Debug.Log(obj.name + " child: " + obj.transform.GetChild(i).gameObject.name);
			if (obj.transform.GetChild(i).gameObject.name == findName)
			{
				return obj.transform.GetChild(i).gameObject;
			}
		}
		return null;
	}
}
