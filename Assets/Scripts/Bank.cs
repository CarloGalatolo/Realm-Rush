using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bank : MonoBehaviour
{
	[SerializeField] TMP_Text displayText;
	[SerializeField] int startingBalance = 150;

	int currentBalance;
	public int CurrentBalance => currentBalance;



	void Awake()
	{
		currentBalance = startingBalance;
		UpdateDisplay();
	}


	public void Deposit(int amount)
	{
		currentBalance += Mathf.Abs(amount);
		UpdateDisplay();
	}


	public void Withdraw(int amount)
	{
		currentBalance -= Mathf.Abs(amount);
		UpdateDisplay();

		if (currentBalance < 0)
		{
			ReloadScene();
		}
	}


	void ReloadScene()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.buildIndex);
	}


	void UpdateDisplay() => displayText.text = $"Gold: {currentBalance}";
}
