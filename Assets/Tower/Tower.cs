using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int cost = 75;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Money money = FindObjectOfType<Money>();

        if (money == null ) 
        {
        return false;
        }

        if (money.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            money.Withdraw(cost);
            return true;
        }

        return false;
    }
}
