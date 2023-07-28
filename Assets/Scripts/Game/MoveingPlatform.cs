using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    public Transform posA, posB;
    public float speed;
    private Vector3 targetposition;

    private void Start()
    {
        targetposition = posA.position;
    }
    private void Update()
    {
        if (Vector2.Distance(platform.transform.position, posA.position) < 0.05f)
        {
            targetposition = posB.position;
        }
        if (Vector2.Distance(platform.transform.position, posB.position) < 0.05f)
        {
            targetposition = posA.position;
        }
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetposition, speed * Time.deltaTime);
    }
}

