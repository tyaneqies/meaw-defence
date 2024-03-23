using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject currentTurret;

    private void OnMouseDown()
    {
        if (currentTurret != null) // node used
        {
            MainGameController.instance.nodeUi.ShowNodeUi(this);
            Debug.Log(" Can't build on this node");
            return;
        }

        MainGameController.instance.nodeUi.HideNodeUi();
        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }

        if(BuildManager.instance.GetTurretToBuild().price > MainGameController.instance.gold) //if no money
        {
            Debug.Log("more gold require to build the turret");
            return;
        }

        currentTurret = Instantiate(BuildManager.instance.GetTurretToBuild().prefab,transform.position, Quaternion.identity);
        MainGameController.instance.gold -= BuildManager.instance.GetTurretToBuild().price;

        BuildManager.instance.ClearTurretTobuild();
    }
}
