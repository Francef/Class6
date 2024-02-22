using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPt;
    private float startDelay = 2f;
    private float repeatRate = 2f;

    List<Obstacle> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<Obstacle>();
    }

    void SpawnObstacle()
    {
        GameObject obj = Instantiate(obstaclePrefab, spawnPt.position, obstaclePrefab.transform.rotation);
        Obstacle obstacle = obj.GetComponent<Obstacle>();
        obstacles.Add(obstacle);
    }

    private void OnEnable()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void OnDisable()
    {
        CancelInvoke();
        for(int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i] != null)
            {
                obstacles[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
