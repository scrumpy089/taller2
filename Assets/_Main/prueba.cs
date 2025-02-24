using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public GameObject[] grids; 
    public GameObject[] players; 
    public Transform[] spawnPoints; 

    private int currentGrid = 0;

    public void SwitchTilemap(GameObject player)
    {
        if (grids.Length == 0 || players.Length == 0 || spawnPoints.Length == 0)
        {
            Debug.LogError(" ERROR: Hay un array vacío en TilemapChanger.");
            return;
        }

       
        grids[currentGrid].SetActive(false);
        players[currentGrid].SetActive(false);

        
        currentGrid = (currentGrid + 1) % grids.Length;

        
        if (currentGrid >= grids.Length || currentGrid >= players.Length || currentGrid >= spawnPoints.Length)
        {
            Debug.LogError(" ERROR: currentGrid fuera de los límites.");
            return;
        }

        
        grids[currentGrid].SetActive(true);
        players[currentGrid].SetActive(true);

        
        player.transform.position = spawnPoints[currentGrid].position;
    }
}
