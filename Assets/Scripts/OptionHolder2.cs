using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionHolder2 : MonoBehaviour {

    public Text thisbutton;
    public GameObject selector;
    public static string optionnName2;
    public static Vector3 optionPos2;
    public static Quaternion optionRot2;


    void Start()
    {
        optionPos2 = gameObject.transform.position;
        optionRot2 = gameObject.transform.rotation;
    }

    void Update()
    {
        optionnName2 = thisbutton.text;
        Debug.Log("" + optionnName2);
    }


}
