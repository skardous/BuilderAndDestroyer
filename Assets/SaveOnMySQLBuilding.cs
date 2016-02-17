using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections.Generic;


public class SaveOnMySQLBuilding : MonoBehaviour {

	public void SaveMyScene()
	{

		GameObject inputFieldGo = GameObject.Find ("BuildingName");
		InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();

		string buildingName = inputFieldCo.text;

		GameControl gameManager = GameObject.Find ("GameControl").GetComponent<GameControl> ();

		SqlManager sqlManager = GameObject.Find ("GameControl").GetComponent<SqlManager> ();
		if (buildingName == "")
			buildingName = "NotNamedBuilding";
		StartCoroutine(sqlManager.PostBuilding (buildingName, gameManager.getSceneString ()));
		print ("toto2");
		
		//PostObject (uid.ToString () + "." + "txt");

	}

	public void UpdatehighScore(InputField newChallenger)
	{
		GameControl gameManager = GameObject.Find ("GameControl").GetComponent<GameControl> ();
		SqlManager sqlManager = GameObject.Find ("GameControl").GetComponent<SqlManager> ();
		
		StartCoroutine(sqlManager.UpdateBuildingScore(gameManager.getId().ToString(), gameManager.getBestScore ().ToString(), newChallenger.text));
		
	}

}
