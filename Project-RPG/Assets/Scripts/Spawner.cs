using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnInterval;

    private void Awake()
    {
        SpawnAfterTime();
    }

    private IEnumerator SpawnObject(float interval, GameObject spawnObject)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(spawnObject, transform.position + spawnPosition, Quaternion.identity, transform);
    }

    public void SpawnAfterTime()
    {
        StartCoroutine(SpawnObject(spawnInterval, spawnObject));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + spawnPosition, 0.3f);
    }
}
