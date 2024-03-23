using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float damage;
    public float bombRange;
    public Transform target;

    public float speed = 10f;

    // Start is called before the first frame update
    public void SetUpRocket(Transform mTarget, float mDamage, float mBombRange) //whats target
    {
        target = mTarget;
        damage = mDamage;
        bombRange = mBombRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //if no target
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //distance between enemy
        float deltaDistance = speed * Time.deltaTime;

        if (dir.magnitude <= deltaDistance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * deltaDistance, Space.World);
        transform.LookAt(target); // for missle head dir
    }

    private void HitTarget()
    {
        Collider[] allObj = Physics.OverlapSphere(target.position, bombRange); //create sphere

        for (int i = 0; i < allObj.Length; i++)
        {
            EnemyComtoller enemy = allObj[i].GetComponent<EnemyComtoller>(); //find target
            if (enemy != null)
            {
                enemy.TakeDamage(damage); //damage of turret
            }
        }

        Destroy(gameObject);
    }
}

