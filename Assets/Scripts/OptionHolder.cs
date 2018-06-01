using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionHolder : MonoBehaviour {

    public Text thisbutton;
    public GameObject selector;
    public static string optionnName1;
    public static Vector3 optionPos1;
    public static Quaternion optionRot1;


    void Start()
    {
        optionPos1 = gameObject.transform.position;
        optionRot1 = gameObject.transform.rotation;
    }

    void Update()
    {
        optionnName1 = thisbutton.text;
        Debug.Log("" + optionnName1);
    }


}
