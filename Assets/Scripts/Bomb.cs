using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;

    void Start()
    {
        explosion = gameObject.transform.Find("Explosion").gameObject;
        IEnumerator explosionCoro = ExplosionSequence();
        StartCoroutine(explosionCoro);
    }

    IEnumerator ExplosionSequence()
	{
        yield return new WaitForSecondsRealtime(1f);
        explosion.SetActive(true);
        Destroy(gameObject,
        explosion.gameObject.transform.Find("ExpAnimator").gameObject.GetComponent<Animator>()
        .GetCurrentAnimatorStateInfo(0).length);
    }
}
