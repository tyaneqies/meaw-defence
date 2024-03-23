using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyComtoller : MonoBehaviour
{
    public float hp = 100;
    private float hpDamage;

    public Transform[] path;

    public float speed = 5f;
    private float speedMultiply = 1f; //speed now
    private float slowTimer = 0;

    private int targetWaypointIndex;

    private int goldDrop = 2;

    public Image hpBar;

    // Start is called before the first frame update
    public void Setup(Transform[] waypoints) //tell enemy where to go
    {
        MainGameController.instance.enemyCount++; //+1 enemy count
        path = waypoints;
        transform.position = path[0].position;
        targetWaypointIndex = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if(MainGameController.instance.isEndGame)
        {
            Destroy(this.gameObject); // destroy if game end
        }

        Vector3 dir = path[targetWaypointIndex].position - transform.position;
        transform.Translate(dir.normalized * speed * speedMultiply* Time.deltaTime, Space.World);

        if (dir.magnitude < 0.1f) // the end of the wave?
        {
            targetWaypointIndex++;
            if (targetWaypointIndex >= path.Length)
            {
                MainGameController.instance.life--; //-player life

                Destroy(gameObject);
            }
        }

        if(slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
        }
        else
        {
            speedMultiply = 1f;
        }
            
    }

    public void TakeDamage(float damage)
    {
        hpDamage += damage;

        hpBar.fillAmount = (hp - hpDamage) / hp;

        if(hpDamage >= hp) //enemy die
        {
            MainGameController.instance.enemyCount--; //-1 enemy count
            MainGameController.instance.gold += goldDrop;
            Destroy(gameObject);
        }
    }
    
    public void Slow(float slowPCT) //Lazer slow
    {
        speedMultiply = 1f - slowPCT;
        slowTimer = 1f;
    }

}
