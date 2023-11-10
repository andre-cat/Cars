using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform zone;
    [SerializeField] private int quantity = 10;
    [SerializeField] private int distanceBetween = 15;
    [SerializeField] private int pileRows = 5;

    void Start()
    {
        float minX = zone.position.x - zone.GetComponent<Renderer>().bounds.size.x / 2f;
        float maxX = zone.position.x + zone.GetComponent<Renderer>().bounds.size.x / 2f;
        
        float minZ = zone.position.z - zone.GetComponent<Renderer>().bounds.size.z / 2f;

        for (int t = 0; t < quantity; t++)
        {
            int randomObject = Random.Range(0, spawnables.Length);

            GameObject spawnable = spawnables[randomObject];

            float w = spawnable.GetComponent<MeshFilter>().sharedMesh.bounds.size.x + 0.25f;
            float h = spawnable.GetComponent<MeshFilter>().sharedMesh.bounds.size.y;

            int type = Random.Range(1, 3);

            int xRandom;

            switch (type)
            {
                case 1:
                    int rows = Random.Range(1, pileRows);
                    int cols = Random.Range(1, pileRows);

                    xRandom = (int)Random.Range(minX + (w * cols / 2), maxX - (w * cols / 2));

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < cols; c++)
                        {
                            float x = (w * c) - (w * cols / 2) + (w / 2) + xRandom;
                            float y = zone.position.y + (h * r);
                            float z = distanceBetween - minZ - t * distanceBetween;
                            Vector3 position = new(x, y, z);
                            Instantiate(spawnable, position, parent.rotation, parent);
                        }
                    }

                    break;
                case 2:

                    int n = Random.Range(1, pileRows);

                    xRandom = (int)Random.Range(minX + (w * n / 2), maxX - (w * n / 2));

                    for (int r = 0; r < n; r++)
                    {
                        for (int c = 0; c < (n - r); c++)
                        {
                            float x = (w * c) - (w * (n - r) / 2) + (w / 2) + xRandom;
                            float y = zone.position.y + (h * r);
                            float z = distanceBetween - minZ - t * distanceBetween;
                            Vector3 position = new(x, y, z);
                            Instantiate(spawnable, position, parent.rotation, parent);
                        }
                    }

                    break;
            }
        }
    }
}
