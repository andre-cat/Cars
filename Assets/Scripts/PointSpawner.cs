using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnables;
    [SerializeField] private Transform parent;
    [SerializeField] private int timeBetween = 5;
    [SerializeField] private int quantity = 10;

    private void Start()
    {
        StartCoroutine(CreateObjects());
    }

    private IEnumerator CreateObjects()
    {
        for (int i = 0; i < quantity; i++)
        {
            int randomObject = Random.Range(0, spawnables.Length);

            GameObject spawnable = spawnables[randomObject];

            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            yield return StartCoroutine(InstantiateAfter(timeBetween, spawnable, new(x, y, z), transform.rotation, parent));
        }
    }

    private IEnumerator InstantiateAfter(float seconds, GameObject gameObject, Vector3 position, Quaternion rotation, Transform parent)
    {
        yield return new WaitForSeconds(seconds);
        Instantiate(gameObject, position, rotation, parent);
        gameObject.SetActive(true);
        yield break;
    }
}
