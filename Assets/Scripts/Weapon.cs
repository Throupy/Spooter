using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class Weapon
	{
		public string name;
		public float fireDelay;
		public float thrustForce;
		public GameObject projectilePrefab;

		public Weapon(string _name, float _fireDelay, float _thrustForce, GameObject _projectilePrefab)
		{
			name = _name;
			fireDelay = _fireDelay;
			thrustForce = _thrustForce;
			projectilePrefab = _projectilePrefab;
		}
	}
}
