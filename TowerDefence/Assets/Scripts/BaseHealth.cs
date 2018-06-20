using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private GameObject loseText;
    [SerializeField] private int health = 20;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Transform healthBar;

    private int currentHealth;
    private MeshRenderer meshRenderer;
    private Vector3 startScale;

    private void Awake()
    {
        meshRenderer = healthBar.GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        currentHealth = health;
        meshRenderer.material.color = gradient.Evaluate(0);
        startScale = healthBar.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyDamage enemy = other.GetComponent<EnemyDamage>();

        if (enemy == null)
            return;

        currentHealth -= enemy.Damage;
        healthBar.localScale = new Vector3(startScale.x, startScale.y,
            Mathf.Lerp(0, startScale.z, currentHealth / (float)health));
        meshRenderer.material.color = gradient.Evaluate(1 - currentHealth / (float)health);

        if(currentHealth <= 0)
        {
            loseText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
