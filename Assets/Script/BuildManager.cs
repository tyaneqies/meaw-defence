using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null) // not avaliable
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public TurretBlueprint basicTurretLv1Blueprint;
    public TurretBlueprint basicTurretLv2Blueprint;
    public TurretBlueprint basicTurretLv3Blueprint;
    public TurretBlueprint launcherTurretLv1Blueprint;
    public TurretBlueprint launcherTurretLv2Blueprint;
    public TurretBlueprint launcherTurretLv3Blueprint;
    public TurretBlueprint LazerTurretLv1Blueprint;
    public TurretBlueprint LazerTurretLv2Blueprint;
    public TurretBlueprint LazerTurretLv3Blueprint;

    private TurretBlueprint turretToBuild; // whats turret player wants to build


    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void OnBasicTurretBtnClick(int level) // All Turret Style
    {
        if(level == 1)
        {
            turretToBuild = basicTurretLv1Blueprint;
        }
        else if (level == 2)
        {
            turretToBuild = basicTurretLv2Blueprint;
        }
        else if (level == 3)
        {
            turretToBuild = basicTurretLv3Blueprint;
        }
    }

    public void OnLauncherTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = launcherTurretLv1Blueprint;
        }
        else if (level == 2)
        {
            turretToBuild = launcherTurretLv2Blueprint;
        }
        else if (level == 3)
        {
            turretToBuild = launcherTurretLv3Blueprint;
        }
    }

    public void OnLazerTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = LazerTurretLv1Blueprint;
        }
        else if (level == 2)
        {
            turretToBuild = LazerTurretLv2Blueprint;
        }
        else if (level == 3)
        {
            turretToBuild = LazerTurretLv3Blueprint;
        }
    }

    public void ClearTurretTobuild()
    {
        turretToBuild = null;
    }
}

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int price;
}
