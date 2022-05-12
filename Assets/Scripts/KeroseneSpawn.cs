using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeroseneSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectArray = new GameObject[15];
    
    [SerializeField] GameObject spawnObject;

    [SerializeField] int spawnAmount;

    [SerializeField] Collider spawnCollider;

    bool objectsSpawned = false;
    bool colliderDisabled = false;

    Vector3 spawnPosition;
    Quaternion spawnRotation;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && ProgressBar.instance.areaObserved)
        {
            SpawnObjectInRandomArea();
            StartCoroutine(DisableCollider());
            objectsSpawned = true;
        }
    }

    public void SpawnObjectInRandomArea()
    {
/*        for (int i = 0; i < spawnAmount; i = i + 1)
        {
            int n = Random.Range(0, gameObjectArray.Length);
            spawnPosition = gameObjectArray[n].transform.position;
            spawnRotation = gameObjectArray[n].transform.rotation;
            Instantiate(spawnObject, spawnPosition, spawnRotation);
            gameObjectArray[n].transform.GetChild(0).gameObject.SetActive(true);
        }*/

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

    IEnumerator DisableCollider()
    {
        spawnCollider.enabled = false;
        colliderDisabled = true;
        yield return new WaitForSeconds(2);
    }
}