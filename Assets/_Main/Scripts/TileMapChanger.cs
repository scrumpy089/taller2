using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileMapChanger : MonoBehaviour
{
    public GameObject[] grids;
    public GameObject[] players;
    public Transform[] PlayerSpawn;
    public GameObject[] pickablesResets;
    

    private int currentGrid = 0;

    public void SwitchTilemap()
    {
        

        grids[currentGrid].SetActive(false);
        players[currentGrid].SetActive(false);

        currentGrid = (currentGrid + 1) % grids.Length;

        grids[currentGrid].SetActive(true);
        players[currentGrid].SetActive(true);

        players[currentGrid].transform.position = PlayerSpawn[currentGrid].position;

        if (currentGrid == 0)
        {
            foreach (GameObject obj in pickablesResets)
            {
                obj.SetActive(true);
            }
        }


    }
}
