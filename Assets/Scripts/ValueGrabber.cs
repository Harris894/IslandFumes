using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using Random = UnityEngine.Random;

public class ValueGrabber : MonoBehaviour {



    static int idNum;
    string name;
    string typeOfThing;
    int cost;
    int profit;
    int airPollution;
    int nuclearWaste;
    int waterPollution;
    int waste;
    string otherEffects;
    int upgrades;
    string upgradesFor;
    string unityName;


    // Use this for initialization
	void Start(){
		

		idNum = Random.Range (1, 15);
		Debug.Log ("" + idNum);
       if (idNum == 5) {
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

            name = reader.GetString(1);
            Debug.Log("" + name);
            typeOfThing = reader.GetString(2);
            cost = reader.GetInt32(3);
            profit = reader.GetInt32(4);
            Debug.Log("" + profit);
            airPollution = reader.GetInt32(5);
            Debug.Log("" + airPollution);
            nuclearWaste = reader.GetInt32(6);
            waterPollution = reader.GetInt32(7);
            waste = reader.GetInt32(8);
            otherEffects = reader.GetString(9);
            Debug.Log("" + otherEffects);
            upgrades = reader.GetInt32(10);
            Debug.Log("" + upgrades);
            upgradesFor = reader.GetString(11);
            unityName = reader.GetString(12);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        //Dim ReadOnly; timeStarted as theId = idNum.Random.Range(1, 10); (supposed to take a static value from a random number between 1 and 10. need testing)

    }
		
	public void DoThisOnClick(){
		//On click it should only change universal values(somehow). money, profit
        //On update it should only display the panel with the extra info.
        //On start, create a variable that takes value only ones. Then according to that number, access the Id's of the database and recall a row.
        //
	}


    //code to make the static number: In your bookmarks.
}
