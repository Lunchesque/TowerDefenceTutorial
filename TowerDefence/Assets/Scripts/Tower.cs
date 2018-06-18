using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackRange = 5;

    private EnemyHealth target;
    private float cooldown;

    private void Update()
    {
        if (target == null)
            FindTarget();
        else
            HitTarget();
    }

    private void FindTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, attackRange);

        for (int i = 0; i < targets.Length; i++)
        {
            EnemyHealth tempTarget = targets[i].GetComponent<EnemyHealth>();

            if (tempTarget == null)
                continue;

            if (target == null)
            {
                target = tempTarget;
                continue;
            }

            float tempDistance = Vector3.Distance(transform.position, tempTarget.transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if(tempDistance < distance)
            {
                target = tempTarget;
            }
        }
    }

    private void HitTarget()
    {
        if(cooldown <= 0.0f)
        {
            target.TakeDamage(damage);
            cooldown = 1 / attackSpeed;
        }

        cooldown -= Time.deltaTime;
    }
}
