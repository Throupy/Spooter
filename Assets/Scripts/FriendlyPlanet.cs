using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyPlanet : MonoBehaviour
{
    public IEnumerator ShootCoro;
    public GameObject shootPoint;
    public GameObject bulletPrefab;
    public GameObject currentlyTargetedEnemy;
    public GameObject pointer;
    public float bulletThrust = 1250f;
    public int price = 10;

    // Start is called before the first frame update
    void Start()
    {
        ShootCoro = Shoot(1f);
        StartCoroutine(ShootCoro);
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isPaused)
		{
            GameObject nearestEnemy = GetNearestEnemy();
            currentlyTargetedEnemy = nearestEnemy;
            Vector3 dif = nearestEnemy.transform.position - pointer.transform.position;
            float angle = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            pointer.transform.rotation = Quaternion.Slerp(pointer.transform.rotation, q, Time.deltaTime * 10);
        }
    }

    IEnumerator Shoot(float waitTime)
	{
        while (true)
		{
            if (!GameManager.instance.isPaused)
			{
                yield return new WaitForSecondsRealtime(waitTime);
                GameObject bullet = Instantiate(bulletPrefab,
                            shootPoint.transform.position,
                            pointer.transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody2D>().AddForce(pointer.transform.up * bulletThrust);
                Destroy(bullet, 2.0f);
            }
            yield return new WaitForSeconds(1);
        }
    }

    public GameObject GetNearestEnemy()
	{
        GameObject bestTarget = gameObject;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;
        foreach (GameObject _potentialTarget in GameManager.instance.enemies)
        {
            GameObject potentialTarget = _potentialTarget;
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
