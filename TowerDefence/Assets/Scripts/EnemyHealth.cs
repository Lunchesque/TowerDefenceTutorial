using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Transform health;
    [SerializeField] private int maxHealth = 2;

    private Vector3 startScale;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        startScale = health.localScale;
    }

    public void TakeDamage(int count)
    {
        currentHealth = Mathf.Max(currentHealth - count, 0);
        health.localScale = new Vector3(startScale.x, startScale.y,
            Mathf.Lerp(0, startScale.z, currentHealth / (float)maxHealth));

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);

        TowerBuilder.Instance.AddCoins(5);
    }
}
