using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    public int sellPrice;
    public Transform target;
    public EnemyComtoller targetEnemy; //for lazer
    public float range = 5f;

    public Transform partToRotate; //which part to rptate

    // Start is called before the first frame update
    public virtual void Start()
    {
        StartCoroutine(UpdateTarget());
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(MainGameController.instance.isEndGame)
        {
            return;
        }

        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position; //rotate dir
        dir.y = 0f; //head radius
        partToRotate.rotation = Quaternion.LookRotation(dir);
    }

    private IEnumerator UpdateTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.25f); // find enemy every 0.25f
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            float shortestDistance = float.MaxValue;
            GameObject nearestEnemy = null;

            for (int i = 0; i < enemies.Length; i++)
            {
                float distanceToEnemy  = Vector3.Distance(transform.position, enemies[i].transform.position); //what enemy near
                if(distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemies[i];
                }
            }

            if(nearestEnemy != null && shortestDistance <= range) //if in raya
            {
                target = nearestEnemy.transform;
                targetEnemy = target.GetComponent<EnemyComtoller>(); //lazer
            }
            else
            {
                target = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); //draw spare on center
    }
}
