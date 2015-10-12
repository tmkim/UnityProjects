using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
    public Camera cam;
    private Vector2 deltaMouseScroll;
    private RaycastHit hit;
    private GameObject cursor;

    // Use this for initialization
    void Start () {
        cursor = GameObject.Find("Cursor");
	}

    // Update is called once per frame
    void Update() {
        //RayCast
        //emit a ray from exactly the middle of the screen
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        //if there was an object intersected
        if (Physics.Raycast(ray, out hit))
        {
            cursor.transform.localScale = new Vector3(0.3f, 0.3f);
            //hit is a reference to the object we intersected with
        }
        else
        {
            cursor.transform.localScale = new Vector3(0.2f, 0.2f);
        }

        //Zooming:
        deltaMouseScroll = Input.mouseScrollDelta;
        cam.fieldOfView -= deltaMouseScroll.y * 2;
        if (cam.fieldOfView < 15f)
        {
            cam.fieldOfView = 15f;
        }
        if (cam.fieldOfView > 100f)
        {
            cam.fieldOfView = 100f;
        }

    }
}
