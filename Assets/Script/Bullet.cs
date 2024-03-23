using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    public Transform target;

    public float speed = 20f;

    // Start is called before the first frame update
    public void SetupBullet(Transform mTarget, float mDamage) //whats target
    {
        target = mTarget;
        damage = mDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) //if no target
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //distance between enemy
        float deltaDistance = speed * Time.deltaTime;

        if(dir.magnitude <= deltaDistance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * deltaDistance, Space.World);
    }

    private void HitTarget()
    {
        EnemyComtoller enemy = target.GetComponent<EnemyComtoller>(); //find target
        if(enemy != null)
        {
            enemy.TakeDamage(damage); //damage of turret
        }


        Destroy(gameObject);
    }
}
