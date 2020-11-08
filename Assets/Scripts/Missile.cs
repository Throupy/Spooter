using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject target;
    public GameObject parentPlanet;
    public Rigidbody2D rb;
    public float missileThrustForce = 1.4f;

	private void Start()
	{
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
    {
        Vector2 direction = (Vector2)target.transform.position - rb.position;
        direction.Normalize();
        float rotationAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotationAmount * 1900f;
        rb.velocity = transform.up * 10;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        // When we hit an enemy
        Destroy(gameObject);
	}
}
