using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LauncherTurret : BaseTurret
{


    public float damage = 10f;
    public float fireRate = 2f; //frequency of ammo
    public float bombRange = 3f; //
    private float fireTimer = 0f; //time of next fire

    public GameObject rocketPrefab;
    public Transform muzzle;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        fireTimer -= Time.deltaTime; //pasokon

        base.Update();
        if (fireTimer <= 0f && target != null)
        {
            Shoot();
            fireTimer = 1f / fireRate; //time of next fire (only 1 time)
        }
    }

    private void Shoot()
    {
        GameObject go = Instantiate(rocketPrefab, muzzle.position, Quaternion.identity); //fire at muzzle

        Rocket missile = go.GetComponent<Rocket>();
        if (missile != null)
        {
            missile.SetUpRocket(target, damage, bombRange); //target of turret is the same as bullet 
        }
        else
        {
            Destroy(go);
        }
    }
}
