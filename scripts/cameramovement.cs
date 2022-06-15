using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
	public float panSpeed = 50f;
	public float panBorderThickness = 10f;

	public float scrollSpeed = 10f;
	public float minY = 20f;
	public float maxY = 200f;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		transform.position = pos;
	}
}
