using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.4f;
    public GameObject player;

	private void Start()
	{
        player = GameObject.Find("Player");
	}

    private void FixedUpdate()
    {
        if (!GameManager.instance.isPaused)
		{
            Vector3 diff = (Vector3.zero - transform.position).normalized;
            // Get the magnitude of the vector using trigonometry
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle));
            float step = speed * Time.fixedDeltaTime;
            Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, step);
        }
    }
}
