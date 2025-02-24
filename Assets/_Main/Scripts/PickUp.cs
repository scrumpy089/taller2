using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private TileMapChanger tileMapChanger;

    public enum PickableType { heart, coin, evolution }
    public PickableType pickableType;
    //public Sprite evolvedSprite;
    //private bool isEvolved = false;

    void Start()
    {
        tileMapChanger = FindObjectOfType<TileMapChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && pickableType == PickableType.heart)
        {
            PlayerController1 player1 = collision.gameObject.GetComponent<PlayerController1>();
            if (player1 != null)
            {
                player1.health = 60.5f;
                this.gameObject.SetActive(false);
                tileMapChanger.SwitchTilemap();

            }

        }
        else if (collision.gameObject.CompareTag("Player2") && pickableType == PickableType.coin)
        {
            PlayerController2 player2 = collision.gameObject.GetComponent<PlayerController2>();
            if (player2 != null)
            {
                player2.coins = 15;
                this.gameObject.SetActive(false);
                tileMapChanger.SwitchTilemap();
            }
        }
        else if (collision.gameObject.CompareTag("Player3") && pickableType == PickableType.evolution)
        {
            PlayerController3 player3 = collision.gameObject.GetComponent<PlayerController3>();
            if (player3 != null)
            {
                player3.evolution = true;
                SpriteRenderer spriteRenderer = player3.GetComponent<SpriteRenderer>();
                /*if (spriteRen != null && evolvedSprite != null)
                {
                    spriteRen.sprite = evolvedSprite;
                    isEvolved = true;
                    Debug.Log("Sprite changed and bool set to true...");
                }*/
                this.gameObject.SetActive(false);
                tileMapChanger.SwitchTilemap();
            }
        }
    }
}