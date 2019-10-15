using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour {

    public Camera mainCam;
    public Camera shootingCam;

    public void goToShootMode()
    {
        Debug.Log("inside");
        mainCam.enabled = false;
        shootingCam.enabled = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("inside");
        mainCam.enabled = false;
        shootingCam.enabled = true;
    }

}
