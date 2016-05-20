using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour {
	public string itemType;
	public GameObject deck;
	public Color[] discColors;
	public Material cardMat;
	public Material cardMatHighlight;
	public bool itemSelected = false;

	private int numCounterIndex = 27; //start at 0 num
	private int discCounterIndex = 0;

	SpriteRenderer sr;
	Vector3 dist;
	Vector2 position;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}


	void OnMouseDown()
	{
		dist = Camera.main.WorldToScreenPoint(transform.position);
		position.x = Input.mousePosition.x - dist.x;
		position.y = Input.mousePosition.y - dist.y;
		Cursor.visible = false;
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1))
		{
			HandleRightClick();
		}
	}

	void OnMouseDrag()
	{
		Vector3 curPos = new Vector3(Input.mousePosition.x - position.x,
		Input.mousePosition.y - position.y, dist.z);

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		transform.position = worldPos;
	}

	void OnMouseUp()
	{
		Debug.Log("Drag ended!");
		Cursor.visible = true;
	}

	void HandleRightClick()
	{
		switch(itemType)
		{
			case "card":
				Debug.Log("its a card!");
				itemSelected = !itemSelected;
				if (itemSelected)
				{
					sr.material = cardMatHighlight;
				}
				else
				{
					sr.material = cardMat;
				}
				break;
			case "discCounter":
				Debug.Log("its a disc counter!");
				sr.color = discColors[discCounterIndex];
				discCounterIndex++;

				if (discCounterIndex >= discColors.Length)
				{
					discCounterIndex = 0;
				}
				break;
			case "numCounter":
				Debug.Log("its a num counter!");
				sr.sprite = deck.GetComponent<Deck>().alphaSprites[numCounterIndex];
				numCounterIndex++;
				if(numCounterIndex >= deck.GetComponent<Deck>().alphaSprites.Length)
				{
					numCounterIndex = 0;
				}
				break;
			default:
				Debug.Log("unknown playable");
				break;
		}
	}


	//void Update()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		RaycastHit hit;
	//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	//		Debug.Log(Input.mousePosition);

	//		if (Physics.Raycast(ray, out hit))
	//		{
	//			if (hit.collider.tag == "Card")
	//			{
	//				Debug.Log("Clicked a card: " + hit.transform.gameObject.name);
	//			}
	//		}
	//	}
	//}
}
