using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseSave : MonoBehaviour
{
    public GameObject player; 

    private string dbName = "URI=file:PlayerStats.db";

    void Start()
    {
        createDB();
        newGame();
        viewStats();
    }

    //creates a table to store player stats if no table containing the data can be located

    public void createDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS player (maxHealth FLOAT, currentHealth FLOAT, " +
                    "attackStrength FLOAT, xp FLOAT, level FLOAT);";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }

    //on a newGame, any current entries in the player table are removed and the starting stats are inserted in their place

    public void newGame()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM player; INSERT INTO player (maxHealth, currentHealth, attackStrength, xp, level) " +
                    "VALUES ('" + 100f +"', '" + 100f +"', '" + 15f +"', '" + 0f +"', '" + 1f +"');";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }

    public void updateStats(float maxHealth, float currentHealth, float attackStrength, float xp, float level)
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE player (maxHealth, currentHealth, attackStrength, xp, level) " +
                    "VALUES ('" + maxHealth +"', '" + currentHealth +"', '" + attackStrength +"', '" + xp +"', '" + level +"');";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }

    public void viewStats()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM player;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Max Health: " + reader["maxHealth"] + " Current Health: " + reader["currentHealth"] + " Attack Strength: " 
                            + reader["attackStrength"]);
                    }

                    reader.Close();
                }
            }
            
            connection.Close();
        }
    }

}
