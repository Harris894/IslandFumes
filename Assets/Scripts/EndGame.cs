﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Escape")
			Application.Quit();
	}

}
