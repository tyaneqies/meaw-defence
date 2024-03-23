using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isWaveEnd = false; //wave end?

    public WaveData[] waves; // how many waves

    public int currentWaveIndex; // now what wave
    public int currentGroupIndex; // now what group

    public Transform[] waypoints; //what path will walk

    // Start is called before the first frame update
    void Start()
    {
        currentGroupIndex = 0;
        currentGroupIndex = 0;
        StartCoroutine(WaveCoroutine());
    }

    private IEnumerator WaveCoroutine() // for spawn group in order
    {
        while(currentWaveIndex < waves.Length) // wave check
        {
            WaveData wavetemp = waves[currentWaveIndex];



            while (currentGroupIndex < wavetemp.groups.Length) // group check
            {
                EnemyGroup grouptemp = wavetemp.groups[currentGroupIndex];

                yield return new WaitForSeconds(wavetemp.delayBeforeWave);

                for (int i = 0; i < grouptemp.enemyCount; i++) //spawn enemies in order
                {
                    if(MainGameController.instance.isEndGame) //is GameEnd??
                    {
                        yield break; // stop coroutine bc game end
                    }

                    GameObject go = Instantiate(grouptemp.enemyPrefab, Vector3.zero, Quaternion.identity);
                    EnemyComtoller enemy = go.GetComponent<EnemyComtoller>();
                    if(enemy == null)
                    {
                        Destroy(go);
                    }
                    else
                    {
                        enemy.Setup(waypoints);
                    }
                    yield return new WaitForSeconds(grouptemp.enemyDelay);
                }
                yield return new WaitForSeconds(grouptemp.nextGroupDelay); // wait for new group
                currentGroupIndex++; // plus new group
            }
            currentGroupIndex = 0; // back to zero
            currentWaveIndex++; //plus new wave
        }
        isWaveEnd = true;
    }
}

[System.Serializable]

public class EnemyGroup //2
{
    public GameObject enemyPrefab;
    public int enemyCount; // how many
    public float enemyDelay; // how deley spawn
    public float nextGroupDelay;
}

[System.Serializable] //1

public class WaveData
{
    public EnemyGroup[] groups; // what group
    public float delayBeforeWave;
}
