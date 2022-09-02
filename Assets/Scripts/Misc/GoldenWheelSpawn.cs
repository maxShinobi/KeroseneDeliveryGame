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
        SpawnObjectInRandomArea();
    }

    public void SpawnObjectInRandomArea()
    {
        for (int i = 0; i < spawnAmount;)
        {
            int n = Random.Range(0, gameObjectArray.Length - 1);

            if (!gameObjectArray[n].transform.GetChild(0).gameObject.activeSelf)
            {
                gameObjectArray[n].transform.GetChild(0).gameObject.SetActive(true);
                i++;
            }
        }
    }
}
