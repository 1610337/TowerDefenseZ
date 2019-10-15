using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    //public GameObject standartTUrretButton;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint gatlinGun;
    public TurretBlueprint crazyGun;
    public TurretBlueprint cloudMaker;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissleLauncher()
    { 
        Debug.Log("Missle Launcher selected Selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
    public void SelectGatlinGun()
    {
        Debug.Log("Missle Launcher selected Selected");
        buildManager.SelectTurretToBuild(gatlinGun);
    }
    public void SelectCrazyGun()
    {
        Debug.Log("Missle Launcher selected Selected");
        buildManager.SelectTurretToBuild(crazyGun);
    }
    public void SelectCloudMaker()
    {
        Debug.Log("Missle Launcher selected Selected");
        buildManager.SelectTurretToBuild(cloudMaker);
    }


}
