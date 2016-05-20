using UnityEngine;
using System.Collections;

public class ScrollCamera : MonoBehaviour {

	public float speed = 10.0f;
	public float zoomSpeed = 2.0f;

	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			if (Input.GetAxis("Mouse X") > 0)
			{
				transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
			}

			else if (Input.GetAxis("Mouse X") < 0)
			{
				transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
			}
		}

		//zoom
		//float scroll = Input.GetAxis("Mouse ScrollWheel");
		//transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
	}
}
