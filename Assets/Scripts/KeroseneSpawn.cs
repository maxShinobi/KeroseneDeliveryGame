using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeroseneSpawn : MonoBehaviour
{
    public static KeroseneSpawn instance;

    [SerializeField] GameObject[] gameObjectArray = new GameObject[15];
    
    [SerializeField] GameObject spawnObject;

    [SerializeField] int spawnAmount;

    [SerializeField] Collider spawnCollider;

    public int playerKerosene;

    private GameObject activeCar;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGameCarSelection.instance.CheckActiveCar();
        activeCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
        playerKerosene = activeCar.GetComponent<PlayerKerosene>().currentValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spawnCollider.enabled = false;
            SpawnObjectInRandomArea();
        }
    }

    public void SpawnObjectInRandomArea()
    {
        for (int i = 0; i < spawnAmount;)
        {
            int n = Random.Range(0, gameObjectArray.Length -1);

            if(!gameObjectArray[n].transform.GetChild(0).gameObject.activeSelf)
            {
                gameObjectArray[n].transform.GetChild(0).gameObject.SetActive(true);
                i++;
            }
        }
    }
}