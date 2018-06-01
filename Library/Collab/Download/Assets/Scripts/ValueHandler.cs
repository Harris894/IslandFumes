using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.SceneManagement;

public class ValueHandler : MonoBehaviour {

    public int myMoney = 10000;
    int profitPerTurn;
    int airPollutionTurn;
    int nuclearWasteTurn;
    int waterPoluttionTurn;
    int wasteTurn;

    public Image waterPollutionBar;
    public Image airPollutionBar;
    public Image nuclearPollutionBar;
    public Image wastBar;

    public Text myMoneyText;
    public Text selectionLabel;
    public DataReceiver dataReceiverClass;
    public Text myProfitText;
    //public Text mySource;
    public Transform buttonHolder;
    public GameObject button;
    public GameObject infoPanel;
    public Text nameOfOption;
    public Text cost;
    public Text type;
    public Text instaProfit;
    public Text profitPerTurnTXT;
    public Text waterPollutionTXT;
    public Text airPollutionTXT;
    public Text nuclearWasteTXT;
    public Text wasteTXT;
    public Text descriptionTXT;


    public List<ListOfDatabase> list = new List<ListOfDatabase>();
    public List<int> selections = new List<int>();




    // Use this for initialization
    void Start () {

        string conn = "URI=file:" + Application.dataPath + "/IslandDeck.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Deck " ;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            ListOfDatabase item= new ListOfDatabase();

            
            item.objectName = reader.GetString(1);
            item.typeOfThing = reader.GetString(2);
            item.cost = reader.GetInt32(3);
            item.get_Money = reader.GetInt32(4);
            item.profit = reader.GetInt32(5);
            item.airPollution = reader.GetInt32(6);
            item.nuclearWaste = reader.GetInt32(7);
            item.waterPollution = reader.GetInt32(8);
            item.waste = reader.GetInt32(9);
            item.otherEffects = reader.GetString(10);
            item.upgrades = reader.GetInt32(11);

            if (item.upgrades == 1)
            {
                item.upgradeNow = true;

            }
            item.unityName = reader.GetString(12);

            list.Add(item);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        print(list[1].objectName);
        print(list[1].cost);
        print(list[1].get_Money);
    }
	
	// Update is called once per frame
	void Update () {
        myMoneyText.text = "" + myMoney;
        myProfitText.text = "" + profitPerTurn;
        
	}

    public void AddToSelection(int idNum)
    {

        

        if (selections.Contains(idNum))
        {
            selections.Remove(idNum);
            myMoney += list[idNum].cost;
            myMoney -= list[idNum].get_Money;
        }
        else
        {
            if (list[idNum].cost > myMoney)
            {
                return;
            }
            selections.Add(idNum);
            myMoney -= list[idNum].cost;
            myMoney += list[idNum].get_Money;
        }


        string temp = "";

        foreach(int content in selections)
        {
            temp += list[content].objectName + "\n";

        }

        selectionLabel.text = temp;
        

    }   

    public void onEndTurn()
    {
        profitPerTurn = 0;
        foreach (int idNum in selections)
        {
            profitPerTurn += list[idNum].profit;
            myMoney += list[idNum].profit;
            airPollutionTurn += list[idNum].airPollution;
            nuclearWasteTurn += list[idNum].nuclearWaste;
            waterPoluttionTurn += list[idNum].waterPollution;
            wasteTurn += list[idNum].waste;
        }

        waterPollutionBar.fillAmount = waterPoluttionTurn / 20.0f;
        airPollutionBar.fillAmount = airPollutionTurn / 20.0f;
        nuclearPollutionBar.fillAmount = nuclearWasteTurn / 20.0f;
        wastBar.fillAmount = wasteTurn / 20.0f;

        selections.Clear();
        selectionLabel.text = "";

        removeButtons();
        generateButtons();

    }


    void removeButtons()
    {
        foreach(Transform options in buttonHolder.transform)
        {
            Destroy(options.gameObject);
        }
    }

    void generateButtons()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject butt = Instantiate(button, buttonHolder) as GameObject;
            butt.GetComponent<DataReceiver>().valueHandlerClass = this;
        }
    }

    public void OnHover()
    {
        infoPanel.gameObject.SetActive(true);
    }

    public void OnExit()
    {
        infoPanel.gameObject.SetActive(false);
    }

    void endSceneTrigger()
    {
        if (waterPoluttionTurn==20 && airPollutionTurn==20 && nuclearWasteTurn==20 && wasteTurn==20)
        {
            SceneManager.LoadScene("EndScene", LoadSceneMode.Additive);
        }
    }

    void grabInfo()
    {
        nameOfOption.text = "" + list[dataReceiverClass.idNum].objectName;
        type.text = "" + list[dataReceiverClass.idNum].typeOfThing;
        cost.text = "" + list[dataReceiverClass.idNum].cost;
        descriptionTXT.text = "" + list[dataReceiverClass.idNum].otherEffects;
        waterPollutionTXT.text = "" + list[dataReceiverClass.idNum].waterPollution;
        airPollutionTXT.text = "" + list[dataReceiverClass.idNum].airPollution;
        nuclearWasteTXT.text = "" + list[dataReceiverClass.idNum].nuclearWaste;
        wasteTXT.text = "" + list[dataReceiverClass.idNum].waste;
        instaProfit.text = "" + list[dataReceiverClass.idNum].get_Money;
        profitPerTurnTXT.text = "" + list[dataReceiverClass.idNum].profit;
    }

}
