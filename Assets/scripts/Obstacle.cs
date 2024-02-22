using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private float speed = 25f;

    private float xBoundary = -20;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if(transform.position.x < xBoundary)
        {
            Destroy(this.gameObject);
        }
    }
}
