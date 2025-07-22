using UnityEngine;
using UnityEngine.Assertions;


public class Enemy : MonoBehaviour
{
	[SerializeField] int goldReward = 25;
	[SerializeField] int goldPenalty = 25;

	Bank bank;

	

	void Start()
	{
		bank = FindFirstObjectByType<Bank>();
		Assert.IsNotNull(bank, "Enemy.Start(): bank not found in the scene.");
	}


	public void RewardGold() => bank.Deposit(goldReward);

	public void StealGold() => bank.Withdraw(goldReward);
}
