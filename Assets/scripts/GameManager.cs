using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Background background;
    [SerializeField] SpawnManager spawnManager;

    public void EndGame()
    {
        Debug.Log("game over");
        background.enabled = false;
        spawnManager.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
