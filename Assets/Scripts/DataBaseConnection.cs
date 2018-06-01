using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;

public class DataBaseConnection : MonoBehaviour {

    public Text buttonText;
    int idNum;
    string optionName;

    // Use this for initialization
    void Start()
    {

        idNum = Random.Range(1, 15);


        
        if (idNum == 5)
        {
            idNum = 1;
        }

        if (idNum == 6)
        {
            idNum = 11;
        }

        string conn = "URI=file:" + Application.dataPath + "/IslandDeck.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT * FROM Deck";
        string sqlQuery = "SELECT * FROM Deck WHERE id=" + idNum + "";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            optionName = reader.GetString(1);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        DisplayInfoOnButton();
    }

    void DisplayInfoOnButton()
    {
        buttonText.text = "" + optionName;
    }
}
