using UnityEngine;
using UnityEngine.Assertions;


public class TargetLocator : MonoBehaviour
{
	[SerializeField] Transform weapon;

	Transform target;



	void Awake()
	{
		Assert.IsNotNull(weapon, "TargetLocator.Awake(): weapon not found in prefab.");
	}


	void Start()
	{
		target = FindFirstObjectByType<EnemyMover>().transform;
	}


	void Update()
	{
		AimWeapon();
	}


	void AimWeapon()
	{
		if (target)
		{
			weapon.LookAt(target);
		}
	}
}
