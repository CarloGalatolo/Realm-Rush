using UnityEngine;
using UnityEngine.Assertions;


public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHitPoints = 5;

	Enemy enemy;

	int currentHitPoints;



	void OnEnable()
	{
		currentHitPoints = maxHitPoints;
	}


	void Awake()
	{
		enemy = GetComponent<Enemy>();
		Assert.IsNotNull(enemy, "EnemyHealth.Start(): enemy not found in the prefab.");
	}


	void OnParticleCollision(GameObject other)
	{
		ProcessHit();
	}


	void ProcessHit()
	{
		currentHitPoints--;

		if (currentHitPoints == 0)
		{
			enemy.RewardGold();
			gameObject.SetActive(false);
		}
	}
}
