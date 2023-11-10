using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform zone;
    [SerializeField] private int quantity = 10;
    [SerializeField] private int distanceBetween = 15;

    void Start()
    {
        for (int t = 0; t < quantity; t++)
        {
            float minX = zone.position.x - zone.GetComponent<Renderer>().bounds.size.x / 2f;
            float maxX = zone.position.x + zone.GetComponent<Renderer>().bounds.size.x / 2f;

            float minZ = zone.position.z - zone.GetComponent<Renderer>().bounds.size.z / 2f;

            int randomObject = Random.Range(0, spawnables.Length);

            GameObject spawnable = spawnables[randomObject];

            float w = spawnable.GetComponent<MeshFilter>().sharedMesh.bounds.size.x + 0.25f;

            int xRandom = (int)Random.Range(minX + (w / 2), maxX - (w / 2));

            float x = xRandom;
            float y = transform.position.y;
            float z = distanceBetween - minZ - t * distanceBetween;

            Vector3 position = new(x, y, z);
            Instantiate(spawnable, position, parent.rotation, parent);
        }
    }
}
