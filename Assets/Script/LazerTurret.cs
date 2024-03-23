using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTurret : BaseTurret
{
    public float damage = 5f;
    [Range(0f, 1f)] //for slow percent
    public float slowPct;
    
    public LineRenderer lineRend;
    public Transform muzzle;

    // Start is called before the first frame update
    public override void Start()
    {
        lineRend = GetComponent<LineRenderer>(); //access linerender in same
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if(target == null)
        {
            if (lineRend.enabled) //if line open = close it
            {
                lineRend.enabled = false;
            }
            return;
        }

        Lazer();
    }

    private void Lazer() //set po
    {
        if (!lineRend.enabled) //poen line
        {
            lineRend.enabled = true;
        }
        lineRend.SetPosition(0, muzzle.position);
        lineRend.SetPosition(1, target.position);

        targetEnemy.TakeDamage(damage * Time.deltaTime); //actta
        targetEnemy.Slow(slowPct); // slow
    }
}
