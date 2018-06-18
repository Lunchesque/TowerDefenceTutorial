using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDamage : MonoBehaviour 
{
	[SerializeField] private int damage = 1;

	public int Damage
	{
		get
		{
			return damage;
		}
	}
}
