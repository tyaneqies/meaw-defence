using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : BaseTurret
{

    public float damage = 10f;
    public float fireRate = 2f; //frequency of ammo
    private float fireTimer = 0f; //time of next fire

    public GameObject bulletPrefab;
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

        base .Update();
        if(fireTimer <= 0f && target != null)
        {
            Shoot();
            fireTimer = 1f / fireRate; //time of next fire (only 1 time)
        }
    }

    private void Shoot()
    {
        GameObject go = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity); //fire at muzzle
        Bullet bullet = go.GetComponent<Bullet>();
        if (bullet != null)
        {
                bullet.SetupBullet(target, damage);
        }
        else
        {
            Destroy(go);
        }
    }
}
