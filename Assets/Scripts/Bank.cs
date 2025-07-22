using System;
using UnityEngine;


public class Bank : MonoBehaviour
{
	[SerializeField] int startingBalance = 150;

	int currentBalance;
	public int CurrentBalance => currentBalance;



	void Awake()
	{
		currentBalance = startingBalance;
	}


	public void Deposit(int amount)
	{
		currentBalance += Mathf.Abs(amount);
	}


	public void Withdraw(int amount)
	{
		currentBalance -= Mathf.Abs(amount);

	}
}
