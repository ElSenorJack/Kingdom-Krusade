using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range (0f, 5f)] float speed = 1f; //Limitiamo la velocità perchè valori negativi darebbero problemi all'equazione e troppo veloce sarebbe brutto

    EnemyTag enemy;
    void OnEnable()
    {
        FindPath();
        ReturntoStart();
        StartCoroutine(FollowPath());
    }
    void Start()
    {
        enemy = GetComponent<EnemyTag>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
        //GameObject parent = GameObject.FindGameObjectWithTag("Path");

        //foreach (Transform child in parent.transform)
        //{
        //   path.Add(child.GetComponent<Waypoint>());
        //}
    }

    void ReturntoStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator FollowPath() //IEnum per ottenere risultati conteggiabili, ma ha bisogno di un Return per avere il risultato
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition); //per ruotare la pedina in direzione del movimento

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame(); //con Yield viene fatta riniziare questa fase in modo ciclico fino alla risoluzione del movimento
            }  
        }
        enemy.Steal();
        gameObject.SetActive(false);
    }
}
