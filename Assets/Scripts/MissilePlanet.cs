using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePlanet : FriendlyPlanet
{
    // Reference to missile
	private Missile currentMissile = null;
    public float fireDelay = 4.0f;
    public GameObject missilePrefab;

    void Start()
    {
        ShootCoro = ShootMissile();
        StartCoroutine(ShootCoro);
    }

	IEnumerator ShootMissile()
    {
        while (true)
        {
            // Control fire rate
            yield return new WaitForSecondsRealtime(fireDelay);
            GameObject missile = Instantiate(missilePrefab,
                    shootPoint.transform.position,
                    pointer.transform.rotation) as GameObject;
            // Supply parent, find nearest target.
            currentMissile = missile.GetComponent<Missile>();
            currentMissile.parentPlanet = gameObject;
            currentMissile.target = GetNearestEnemy();
            // If there is no nearest enemy, as the target then defaults to the planet.
            // See FriendlyPlanet.GetNearestEnemy()
            if(currentMissile.target.transform.position == gameObject.transform.position)
			{
                Destroy(missile);
			}
            Destroy(missile, 5.0f);

        }
    }
}
