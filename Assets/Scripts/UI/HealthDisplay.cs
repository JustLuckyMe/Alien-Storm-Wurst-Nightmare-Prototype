using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
	public int maxHealth;
	public int health;

	public Player playerHealth; // reference the player script thast has the player's health

	public Sprite emptyHeart;
	public Sprite fullHeart;
	public Image[] hearts;

	void Update()
	{

		health = playerHealth.currentHealth;
		maxHealth = playerHealth.maxHealth;

		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < health)
			{
				hearts[i].sprite = fullHeart;
				// hearts[i].enabled = true
			}
			else
			{
				hearts[i].sprite = emptyHeart;
				// hearts[i].enabled = false
			}
		}

	}

}