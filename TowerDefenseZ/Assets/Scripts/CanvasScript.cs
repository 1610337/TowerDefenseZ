// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;



public class CanvasScript : MonoBehaviour
{
    private float rotSpeed = 20;
    public Transform partToRotate;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        Debug.Log("Trying hard");
        partToRotate.Rotate(Vector3.up, -rotX);
        partToRotate.Rotate(Vector3.up, -rotY);
    }
}
