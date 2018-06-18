using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float waveDelay = 10.0f;
    [SerializeField] private WaveInfo[] waves;

    [System.Serializable]
    private class WaveInfo
    {
        public UnityKeyValue[] pair;
        public float spawnDelay;

        public GameObject GetNextEnemy()
        {
            for (int i = 0; i < pair.Length; i++)
            {
                if (pair[i].value == 0)
                    continue;

                GameObject enemy = pair[i].key;
                pair[i].value--;
                return enemy;
            }

            return null;
        }
    }

    [System.Serializable]
    private class UnityKeyValue
    {
        public GameObject key;
        public int value;
    }

    private bool isWave;
    private float currentTime;
    private int currentWave;

    private void Start()
    {
        currentTime = waveDelay;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (isWave)
            ProcessWave();
        else
            Wait();
    }

    private void Wait()
    {
        if(currentTime >= waveDelay)
        {
            currentTime = 0.0f;
            isWave = true;
        }
    }

    private void ProcessWave()
    {
        if (currentWave >= waves.Length)
            return;

        if (currentTime >= waves[currentWave].spawnDelay)
        {
            currentTime = 0.0f;

            GameObject enemy = waves[currentWave].GetNextEnemy();

            if(enemy == null)
            {
                currentWave++;
                currentTime = 0.0f;
                isWave = false;
                return;
            }

            GameObject newEnemy = Instantiate(enemy);
            newEnemy.SetActive(true);
        }
    }
}
