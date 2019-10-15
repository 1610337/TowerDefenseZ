using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    public static CanvasChanger instance;

    public GameObject mainCanvas;
    public GameObject shootingCanvas;
    public GameObject pauseCanvas;

    public GameObject mainCamera;

    [Header("Deactivate when in SHooting Mode")]
    public GameObject dismis;
    public GameObject up;
    public GameObject sell;

    private GameObject currentShootingTurret;

    // Use this for initialization
    void Start()
    {
        shootingCanvas.SetActive(false);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Canvas in scene!");
            return;
        }
        instance = this;

    }

    public void activateShootingCanvas(GameObject currentShootingTurretX)
    {
        this.currentShootingTurret = currentShootingTurretX;
        mainCanvas.SetActive(false);
        shootingCanvas.SetActive(true);

        dismis.SetActive(false);
        up.SetActive(false);
        sell.SetActive(false);
    }
    public void leaveShootMode()
    {
        this.currentShootingTurret.GetComponent<Turrent>().leaveShootMode();
        mainCanvas.SetActive(true);
        shootingCanvas.SetActive(false);

        BuildManager.instance.DeselectNode();

    }
    public void invokeShoot()
    {
        this.currentShootingTurret.GetComponent<Turrent>().shootStraight();
    }

    /*
     * Methods related to pause screen
     */
    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void changeViewOfMainCamera()
    {
        if(mainCamera.transform.position == new Vector3(52.7f, 38.6f, 53.2f))
        {
            mainCamera.transform.position = new Vector3(52.7f, 26.2f, 31.12f);
            mainCamera.transform.eulerAngles = new Vector3(53.11f, 0, 0);
        }
        else
        {
            mainCamera.transform.position = new Vector3(52.7f, 38.6f, 53.2f);
            mainCamera.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
