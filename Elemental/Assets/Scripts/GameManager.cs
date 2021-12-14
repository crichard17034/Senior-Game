﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject databaseSave;
    public GameObject player;

    void Start()
    {
        searchForPlayer();
        searchForDatabase();
        sendStatsToPlayer(player);
    }

    void Awake()
    {
        searchForPlayer();
        searchForDatabase();
        sendStatsToPlayer(player);
    }

    public void newGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void continueGame()
    {
        SceneManager.LoadScene(1);
    }

    //checks if a game object with the tag "Player" is present and sets the value of the player variable
    public void searchForPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    //checks if a game object with the tag "Database" is present within the current scene and sets the value of
    //the databaseSave value accordingly

    public void searchForDatabase()
    {
        if (databaseSave == null)
        {
            databaseSave = GameObject.FindWithTag("Database");
        }
    }

    public void sendStatsToPlayer(GameObject player)
    {
        databaseSave.GetComponent<DatabaseSave>().obtainStats(player);
    }

    public void updateDatabase(int mHP, int cHP, int aTK, int lV, int xP, int goalXP)
    {
        databaseSave.GetComponent<DatabaseSave>().updateStats(mHP, cHP, aTK, lV, xP, goalXP);
    }

    public void getPlayerStats()
    {
        player.GetComponent<PlayerController>().sendStats();
    }

    // takes in a string containing the name of a scene and loads it through SceneManager
    public void Teleport(string location)
    {
        getPlayerStats();
        SceneManager.LoadScene(location);
    }    
    
    //allows the cursor to freely move on screen when on menus
    public void unlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
