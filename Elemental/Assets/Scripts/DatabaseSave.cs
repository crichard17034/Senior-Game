using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseSave : MonoBehaviour
{
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
                    "attackStrength FLOAT, xp INT, level INT);";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }

    public void newGame()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO player (maxHealth, currentHealth, attackStrength, xp, level) " +
                    "VALUES ('" + 103f +"', '" + 100f +"', '" + 15f +"', '" + 0 +"', '" + 1 +"');";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }

    public void updateStats(float maxHealth, float currentHealth, float attackStrength, int xp, int level)
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
                        Debug.Log("Max Health: " + reader["maxHealth"] + "Current Health: " + reader["currentHealth"] + "Attack Strength: " 
                            + reader["attackStrength"]);  
                    }

                    reader.Close();
                }
            }
            
            connection.Close();
        }
    }

}
