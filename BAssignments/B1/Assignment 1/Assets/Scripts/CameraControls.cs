using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    public float speed;
    private Vector3 mousePosition;

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        //if left click and cursor isn't locked
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveForward = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveForward);
        transform.Translate(movement * speed);

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            //Rotation
            //yaw rotation
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            //pitch
            gameObject.transform.GetChild(0).transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        }
    }
}
