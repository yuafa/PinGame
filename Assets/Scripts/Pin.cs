using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float moveSpeed = 1f;

    [HideInInspector]
    public Transform target;

    private bool isReach = false;

    private void Update()
    {
        if (isReach) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 1f)
        {
            GameManager.instance.AddScore();
            isReach = true;
            transform.position = (transform.position - target.position).normalized;
            transform.parent = target;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Pin"))
        //{
        //    GameManager.instance.GameOver();
        //}
    }

}
