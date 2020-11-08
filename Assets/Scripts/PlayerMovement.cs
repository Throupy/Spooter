using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMovement;
    float moveSpeed = 250f; 

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal"); 
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isPaused)
		{
            transform.RotateAround(Vector3.zero, Vector3.forward, horizontalMovement * Time.fixedDeltaTime * -moveSpeed);
        }
    }
}
