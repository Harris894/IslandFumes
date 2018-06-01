using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class DataReceiver : MonoBehaviour
{

    public int idNum;

    public Text nameLabel;
    public Image iconImage;
    public ValueHandler valueHandlerClass;
    public Text selectionLabel;


    // Use this for initialization
    void Start()
    {

        idNum = Random.Range(1, 15);
        DisplayInfoOnButton();
    }


    void DisplayInfoOnButton()
    {
        nameLabel.text = "" + valueHandlerClass.list[idNum].objectName;
    }

    public void displaySelection()
    {
        valueHandlerClass.AddToSelection(idNum);

        /*
        valueHandlerClass.AddToSelection(idNum);
        valueHandlerClass.myMoney = valueHandlerClass.myMoney - valueHandlerClass.list[idNum].cost + valueHandlerClass.list[idNum].get_Money;
        */
    }

}
