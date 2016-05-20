using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public GameObject pfGridCell;
	public Vector2 gridSize;
	public Vector2 gridOffset;
	public Vector3 gridLocation = new Vector3(0.77f, -1.08f, 0f);
	public Sprite[] rowHeaders;
	public Sprite[] columnHeaders;
	public GameObject gridGroup;

	SpriteRenderer spriteRenderer;


	void Start()
	{
		MakeGrid();
	}

	public void MakeGrid()
	{
		GameObject cell;
		Vector3 newLoc = gridLocation;
		bool showRowHeader = true;
		bool showColumnHeader = true;

		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				cell = GameObject.Instantiate(pfGridCell) as GameObject;
				cell.transform.position = newLoc;
				cell.transform.parent = gridGroup.transform;

				newLoc.x = newLoc.x + gridOffset.x;

				if (j == 0) { showRowHeader = true; } else { showRowHeader = false; }
				if (i == 0) { showColumnHeader = true; } else { showColumnHeader = false; }

				if (showRowHeader)
				{
					GameObject cellObj = getChildObject(cell, "Cell");
					GameObject row = getChildObject(cellObj, "Row");
					row.SetActive(true);
					spriteRenderer = row.GetComponent<SpriteRenderer>();
					spriteRenderer.sprite = rowHeaders[i];
				}
				if(showColumnHeader)
				{
					GameObject cellObj = getChildObject(cell, "Cell");
					GameObject column = getChildObject(cellObj, "Column");
					column.SetActive(true);
					spriteRenderer = column.GetComponent<SpriteRenderer>();
					spriteRenderer.sprite = columnHeaders[j];
				}
			}
			newLoc.x = gridLocation.x;
			newLoc.y = newLoc.y + gridOffset.y;
		}
	}

	GameObject getChildObject(GameObject obj, string findName)
	{
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			//Debug.Log(obj.name + " child: " + obj.transform.GetChild(i).gameObject.name);
			if (obj.transform.GetChild(i).gameObject.name == findName)
			{
				return obj.transform.GetChild(i).gameObject;
			}
		}
		return null;
	}
}
