using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	public List<Weapon> weapons = new List<Weapon>();
	public GameObject bulletPrefab;
	public GameObject bombPrefab;
	public GameObject shootPoint;
	public GameObject weaponSelectionPanel;
	private Weapon currentWeapon;
	public float bulletThrust = 500f;

	int currentElementIndex = 0;

	private void Start()
	{
		Weapon machineGun = new Weapon("MACHINE GUN", 0f, 500f, bulletPrefab);
		Weapon bomb = new Weapon("BOMB", 4f, 100f, bombPrefab);
		weapons.Add(machineGun); weapons.Add(bomb);
		currentWeapon = machineGun;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !GameManager.instance.isPaused)
		{
			GameObject bullet = Instantiate(currentWeapon.projectilePrefab, 
								shootPoint.transform.position,
								transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * currentWeapon.thrustForce);
			Destroy(bullet, 2.0f);
		} else if (Input.GetKeyDown(KeyCode.Tab) && !GameManager.instance.isPaused)
		{
			IEnumerator weaponWheelCoro = WeaponWheel();
			StartCoroutine(weaponWheelCoro);			
		}
	}

	IEnumerator WeaponWheel()
	{
		weaponSelectionPanel.SetActive(true);
		// Get next weapon index
		currentElementIndex++;
		if (currentElementIndex == weapons.Count)
		{
			currentElementIndex = 0;
		}
		// Set next weapon variable
		Weapon nextWeapon = weapons[currentElementIndex];
		currentWeapon = nextWeapon;
		// Display new weapon
		weaponSelectionPanel.GetComponentInChildren<TMP_Text>().text = currentWeapon.name;
		yield return new WaitForSecondsRealtime(2f);
		weaponSelectionPanel.SetActive(false);
	}


}
