using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.LookAt(target);
    }
}