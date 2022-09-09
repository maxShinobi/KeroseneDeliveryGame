using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenWheelSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectArray = new GameObject[20];

    [SerializeField] GameObject spawnObject;

    [SerializeField] int spawnAmount;

    private void Start()
    {
        InvokeRepeating("DestroyPreviouslySpawnedObjects", 2f, 2f);
        InvokeRepeating("SpawnObjectsInRandomArea", 0.1f, 3f);
    }

    private void SpawnObjectsInRandomArea()
    {
        for (int i = 0; i < spawnAmount;)
        {
            int n = Random.Range(0, gameObjectArray.Length - 1);

            if (!gameObjectArray[n].transform.GetChild(0).gameObject.activeInHierarchy)
            {
                gameObjectArray[n].transform.GetChild(0).gameObject.SetActive(true);
                i++;
            }
        }
    }

    private void DestroyPreviouslySpawnedObjects()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GoldenWheel"))
        {
            obj.SetActive(false);
        }
    }
}
