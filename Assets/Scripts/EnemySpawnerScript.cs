using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public float MaxSpawmTime = 8;
    public float MinSpawnTime = 4;
    public EnemyAI enemyPrefab;
    private EnemyAI _enemyspawn;
    
    void Start()
    {
        
    }

    
    private void Update()
    {
        if(IsInvoking()) return;
        Invoke("CreateEnemy", Random.Range(MinSpawnTime, MaxSpawmTime));
    }
    private void CreateEnemy()
    {
        _enemyspawn = Instantiate(enemyPrefab);
        _enemyspawn.transform.position = transform.position;
    }
}
