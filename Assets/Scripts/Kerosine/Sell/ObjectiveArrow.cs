using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    private void Start()
    {
        //arrow.SetActive(false);
    }

    private void Update()
    {
        FindClosestBucket();
    }

    private void FindClosestBucket()
    {
        float distanceToClosestBucket = Mathf.Infinity;
        Bucket closestBucket = null;
        Bucket[] allBuckets = GameObject.FindObjectsOfType<Bucket>();

        foreach(Bucket currentBucket in allBuckets)
        {
            float distanceToBucket = (currentBucket.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToBucket < distanceToClosestBucket)
            {
                distanceToClosestBucket = distanceToBucket;
                closestBucket = currentBucket;

                //arrow.SetActive(true);
                //transform.LookAt(new Vector2(closestBucket.transform.position.x, closestBucket.transform.position.y));
                var lookPos = closestBucket.transform.position - this.transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

                if(closestBucket = null)
                {
                    //arrow.SetActive(false);
                }
            }
        }
    }
}