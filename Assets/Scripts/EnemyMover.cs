using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (FollowPath());
    }

    IEnumerator FollowPath() //IEnum per ottenere risultati conteggiabili, ma ha bisogno di un Return per avere il risultato
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;

            yield return new WaitForSeconds(waitTime); //il return rimanda la lettura del codice dopo 1 secondo, tornando a vv
                                                 // Start> CalLmethod> IEnum legge il primo valore> aspetta 1 sec > Start
        }
    }
}
