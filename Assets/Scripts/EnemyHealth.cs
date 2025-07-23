using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHitPoints = 5;
	[SerializeField] int difficultyRamp = 1;

	Enemy enemy;

	int currentHitPoints;



	void OnEnable()
	{
		currentHitPoints = maxHitPoints;
	}


	void Awake()
	{
		enemy = GetComponent<Enemy>();	// Required.
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
			maxHitPoints += difficultyRamp;
			gameObject.SetActive(false);
		}
	}
}
