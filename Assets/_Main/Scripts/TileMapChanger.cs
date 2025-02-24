using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileMapChanger : MonoBehaviour
{
    public GameObject[] grids;
    public GameObject[] players;
    public Transform[] PlayerSpawn;

    private int currentGrid = 0;

    public void SwitchTilemap(GameObject player)
    {
        /*if (grids.Length == 0 || players.Length == 0 || PlayerSpawn.Length == 0)
        {
            Debug.LogError(" ERROR: Hay un array vacío en TilemapChanger.");
            return;
        }*/


        grids[currentGrid].SetActive(false);
        players[currentGrid].SetActive(false);


        currentGrid = (currentGrid + 1) % grids.Length;


        /*if (currentGrid >= grids.Length || currentGrid >= players.Length || currentGrid >= PlayerSpawn.Length)
        {
            Debug.LogError(" ERROR: currentGrid fuera de los límites.");
            return;
        }*/


        grids[currentGrid].SetActive(true);
        players[currentGrid].SetActive(true);


        player.transform.position = PlayerSpawn[currentGrid].position;

        
    }
}
