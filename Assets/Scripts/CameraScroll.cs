using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    private Camera cam;
    public float minZoom = 2f;
    public float maxZoom = 10f;

	private void Start()
	{
        cam = this.GetComponent<Camera>();
	}
	void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            // Mathf.clamp will only return the value if it's between the min and max values specified.
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + Input.GetAxis("Mouse ScrollWheel"), 
                minZoom, maxZoom);
        }
    }
}
