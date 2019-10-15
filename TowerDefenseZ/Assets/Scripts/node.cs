using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    public Material GlowMaterial;
    public Material NormalMaterial;

    [Header ("Optional")]
    public GameObject turret;

    public bool turretIsUpgraded = false;

    private Renderer rend;
    private Color startColor;

    // variables to detect double click
    private float downTime; //internal time from when the key is pressed
    private bool isHandled = false;
    private float lastClick = 0;
    private float waitTime = 1.0f; //wait time befor reacting
    private bool justBuild = true;
    public bool CrazyGunInShootingMode = false;
    private TurretBlueprint turretBlueprint;



    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    private void OnMouseDown()
    {
      
        if (buildManager.getGunInShootingMode())
        {
            return;
        }


        
        downTime = Time.time;
        isHandled = false;
        //look for a double click
        if (Time.time - lastClick < 0.3)
        {
            // do something because of double click

           

            if (turret != null)
            {
                Debug.Log("Can't built there! - TODO Display on screen");
                if(turret.GetComponent<Turrent>().getName() == "CrazyGun")
                {
                        buildManager.SelectNode(this);
                        Debug.Log("Theres a CrazyFGun Change the camera");

                        Turrent tempTurrent = turret.GetComponent<Turrent>();
                        tempTurrent.setNode(this);
                        tempTurrent.goToShootMode();
                    //this.CrazyGunInShootingMode = true;
                    buildManager.GunInShootingMode();
                    //buildManager.SelectNode(this);

                    return;
                    // deactivate all mouse down etc functions untill a certein method (to implement) is invoked

                }
                else
                {
                    buildManager.SelectNode(this); // UI to upgrade
                }
                return;
            }
            // check if turret can be build otherwise return
            if (!buildManager.CanBuild)
            {              
                return;
            }

            // buildManager.BuildTurretOn(this);
            BuildTurret(buildManager.GetTurretToBuild());
            Turrent tempTurrent1 = turret.GetComponent<Turrent>();
            tempTurrent1.setNode(this);
            justBuilt();
        }
        lastClick = Time.time;
        BuildManager.instance.DeselectNode();
    }
    void BuildTurret(TurretBlueprint blueprint)
        {

            if (PlayerStats.Money < blueprint.cost)
            {
                Debug.Log("Not enough money");
                return;
            }
        // built a turret
        // PlayerStats.Money = PlayerStats.Money - turretToBuild.cost;

            turretBlueprint = blueprint;

            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            PlayerStats.instance.ReduceMoney(blueprint.cost);

            Debug.Log("Turret build!");


    }
    private void justBuilt()
    {
        justBuild = true;
    }

    public void crazyGunNotInShootingMode()
    {
        buildManager.GunNotInShootingMode();
        rend.material.color = startColor;
        justBuild = false;
    }

    private void OnMouseEnter()
    {

        if (buildManager.getGunInShootingMode())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }
    private void OnMouseExit()
    {
        if (buildManager.getGunInShootingMode())
        {
            return;
        }

        rend.material.color = startColor;
        justBuild = false;
    }
    
    public void UpgradeTurret()
    {
        
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        }
        if(turret.GetComponent<Turrent>().getName() == "CrazyGun")
        {
            CanvasChanger.instance.leaveShootMode();
        }
       
        // built a turret
        // PlayerStats.Money = PlayerStats.Money - turretToBuild.cost;

        // kill the old turret
        Destroy(turret);

        // build new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        PlayerStats.instance.ReduceMoney(turretBlueprint.upgradeCost);
        turretIsUpgraded = true;


        Debug.Log("Turret upgraded!");

    }

    public int getTurretBlueprintUpdatecost()
    {
        return turretBlueprint.upgradeCost;
    }
    public int getTurretBlueprintSaleProfit()
    {
        return turretBlueprint.GetSellAmount();
    }

    public void SellTurret()
    {
        PlayerStats.instance.IncreaseMoney(turretBlueprint.GetSellAmount());
        //spawn effect

        Destroy(turret);
        turretBlueprint = null;
    }

    public void instantiateGlowingEffect()
    {
        this.GetComponent<MeshRenderer>().material = GlowMaterial;
        Invoke("getOldEffect", 0.3f);
    }
    public void getOldEffect()
    {
        this.GetComponent<MeshRenderer>().material = NormalMaterial;
    }

}
