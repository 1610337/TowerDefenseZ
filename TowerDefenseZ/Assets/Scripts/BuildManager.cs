using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;

    }

    public GameObject standardTurretPrefab;
    public GameObject missleLauncherPrefab;
    public GameObject GatlinGunPrefab;
    public GameObject crazyGunPrefab;
    public GameObject cloudMakerPrefab;

    private bool GunInShootMode = false;

    private TurretBlueprint turretToBuild;
    private node selectedNode;
    public NodeUI nodeUI;

    // called a property, only there to get something if it is there otherwise return false
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost;  } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null; // change the graphics then if i reach that point

        DeselectNode();
    }
    public void SelectNode (node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null; // change the graphics then if i reach that point

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void GunNotInShootingMode()
    {
        GunInShootMode = false;
    }
    public void GunInShootingMode()
    {
        GunInShootMode = true;
    }
    public bool getGunInShootingMode()
    {
        return GunInShootMode;
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
