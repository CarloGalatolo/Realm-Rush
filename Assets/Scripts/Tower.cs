using System;
using UnityEngine;


public class Tower : MonoBehaviour
{
	[SerializeField] int cost = 75;



	internal bool CreateTower(Vector3 position)
	{
		Bank bank = FindObjectOfType<Bank>();

		if (bank == null || bank.CurrentBalance < cost)
		{
			return false;
		}

		bank.Withdraw(cost);
		Instantiate(this.gameObject, position, Quaternion.identity);
		return true;
	}
}
