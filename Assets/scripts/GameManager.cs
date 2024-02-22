using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Background background;
    [SerializeField] SpawnManager spawnManager;
    Coroutine pauseBeforeReset;

    public void EndGame()
    {
        Debug.Log("game over");
        background.enabled = false;
        spawnManager.enabled = false;
        pauseBeforeReset = StartCoroutine(ResetPause());
    }

    public void Reset()
    {
        spawnManager.DestroyObstacles();
        background.enabled = true;
        spawnManager.enabled = true;
        playerController.Reset();
    }

    IEnumerator ResetPause()
    {
        yield return new WaitForSeconds(3);
        Reset();
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
