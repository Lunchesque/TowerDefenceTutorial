using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{
    public static TowerBuilder Instance { get; private set; }

    [SerializeField] private Text coinsCounter;
    [SerializeField] private Tower[] towers;
    [SerializeField] private int coins = 50;

    private Platform currentPlatform;

    private int Coins
    {
        get
        {
            return coins;
        }

        set
        {
            coins = value;
            coinsCounter.text = "Coins: " + coins;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsCounter.text = "Coins: " + coins;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                if (currentPlatform != null)
                    currentPlatform.Select(false);
                currentPlatform = hit.collider.GetComponent<Platform>();
                if (currentPlatform != null)
                    currentPlatform.Select(true);
            }
        }
    }

    public void BuildTower(int index)
    {
        if (currentPlatform == null || currentPlatform.HasTower)
            return;

        if(index >= towers.Length)
        {
            Debug.LogWarning("You don't have this tower type.");
            return;
        }

        if(towers[index].Cost > coins)
        {
            Debug.LogWarning("No coins!");
            return;
        }

        Tower t = Instantiate(towers[index]);
        currentPlatform.AddTower(t.gameObject);
        t.transform.SetParent(currentPlatform.transform);
        t.transform.localPosition = Vector3.zero;

        Coins -= t.Cost;
    }

    public void AddCoins(int count)
    {
        Coins += count;
    }
}
