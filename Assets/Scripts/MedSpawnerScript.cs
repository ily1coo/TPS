using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedSpawnerScript : MonoBehaviour
{
    public Med MedPrefab;
    public float delayMin = 3;
    public float delayMax = 10;
    private Med _med;

    public List<Transform> spawnerPoints;

    private void Update()
    {
        if(_med != null) return;
        if(IsInvoking()) return;
        Invoke("CreateMed", Random.Range(delayMin, delayMax));
    }

    private void CreateMed()
    {
        _med = Instantiate(MedPrefab);
        _med.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
    }
}
