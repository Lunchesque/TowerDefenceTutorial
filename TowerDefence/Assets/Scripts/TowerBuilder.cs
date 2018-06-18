using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;

    private Platform currentPlatform;

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

        GameObject t = Instantiate(towers[index]);
        currentPlatform.AddTower(t);
        t.transform.SetParent(currentPlatform.transform);
        t.transform.localPosition = Vector3.zero;
    }
}
