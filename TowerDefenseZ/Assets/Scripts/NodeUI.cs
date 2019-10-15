using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {


    public GameObject ui;
    public GameObject ui1;
    public GameObject ui2;

    private node target;
    public GameObject canvasToHide;

    public GameObject platformToMarkSpawn;

    public void SetTarget(node target)
    {
        this.target = target;
        if (target.turretIsUpgraded)
        {
            return;
        }
        transform.position = target.GetBuildPosition();

        platformToMarkSpawn = Instantiate(platformToMarkSpawn, transform.position, Quaternion.identity);
        platformToMarkSpawn.SetActive(true);

        //Text button = ui.GetComponentInChildren<Text>();
        Text button = ui.GetComponentsInChildren<Text>()[1];
        int upgradeCosts = target.getTurretBlueprintUpdatecost();
        button.text = upgradeCosts.ToString() + ".- USD";

        button = ui1.GetComponentsInChildren<Text>()[1];
        int sellProfit = target.getTurretBlueprintSaleProfit();
        button.text = sellProfit.ToString() + ".- USD";


        ui.SetActive(true);
        ui1.SetActive(true);
        ui2.SetActive(true);
        canvasToHide.SetActive(false);
    }
    public void Hide()
    {
        ui.SetActive(false);
        ui1.SetActive(false);
        ui2.SetActive(false);
        platformToMarkSpawn.SetActive(false);
        canvasToHide.SetActive(true);
    }
    public void Upgrade()
    {
        Debug.Log("i need to upgrade");
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();

        CanvasChanger.instance.leaveShootMode();
    }

    public void Sell()
    {
        Debug.Log("i need to sell");
        target.SellTurret();
        BuildManager.instance.DeselectNode();

        CanvasChanger.instance.leaveShootMode();
  

    }
}
