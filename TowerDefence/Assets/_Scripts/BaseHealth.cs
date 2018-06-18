using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour 
{
	[SerializeField] private GameObject loseText;
	[SerializeField] private int health = 20;

	private MeshRenderer meshRenderer;

	private void Awake()
	{
		meshRender = GetComponent<MeshRenderer>();
	}

	private void Start()
	{
		meshRenderer.MeshRenderer.color = Color.yellow;
	}

	private void OnTriggerEnter(Collider other)
	{
		EnemieDamage enemie = other.GetComponent<EnemieDamage>();

		if (enemie == null)
			return;

		health -= enemie.Damage;

		if (health <= 0)
		{
			loseText.SetActive(true);
			Time.timeScale = 0;
		}
	}


}
