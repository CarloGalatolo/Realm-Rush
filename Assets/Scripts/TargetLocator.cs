using UnityEngine;
using UnityEngine.Assertions;


public class TargetLocator : MonoBehaviour
{
	[SerializeField] Transform weapon;

	[Tooltip("The size of a tile is 10 units.")]
	[SerializeField] float range = 15;

	Transform target;
	ParticleSystem projectileParticle;



	void Awake()
	{
		Assert.IsNotNull(weapon, "TargetLocator.Awake(): weapon not found in prefab.");
	}


	void Start()
	{
		projectileParticle = GetComponentInChildren<ParticleSystem>();
		Assert.IsNotNull(projectileParticle, "TargetLocator.Start(): projectileParticle not found in children.");
	}


	void Update()
	{
		FindClosestTarget();
		AimWeapon();
	}


	void FindClosestTarget()
	{
		if (target != null)
		{
			return;
		}

		Enemy[] enemies = FindObjectsOfType<Enemy>();

		if (enemies.Length == 0)
		{
			return;
		}

		Transform closestTarget = null;
		float maxDistance = range;

		foreach (Enemy enemy in enemies)
		{
			float targetDistance = Vector3.Distance(this.transform.position, enemy.transform.position);

			if (targetDistance < maxDistance)
			{
				closestTarget = enemy.transform;
				maxDistance = targetDistance;
			}
		}

		target = closestTarget;
	}


	void AimWeapon()
	{
		if (target && Vector3.Distance(this.transform.position, target.position) <= range)
		{
			Attack(true);
			weapon.LookAt(target);
		}
		else
		{
			Attack(false);
			weapon.transform.rotation = Quaternion.identity;	// Feedback that the target is lost.
			target = null;	// Lose target.
		}
	}


	void Attack(bool active)
	{
		ParticleSystem.EmissionModule emissionModule = projectileParticle.emission;
		emissionModule.enabled = active;
	}
}
