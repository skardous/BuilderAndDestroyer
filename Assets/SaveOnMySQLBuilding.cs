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
		print ( "TEMP ==== " + Application.temporaryCachePath);

		System.Guid uid = System.Guid.NewGuid();

		System.IO.File.WriteAllText(Application.temporaryCachePath + Path.DirectorySeparatorChar + uid.ToString() + "." + "txt", gameManager.getSceneString());
		print ( "File saved at ==== " + Application.temporaryCachePath + Path.DirectorySeparatorChar + uid.ToString() + "." + "txt");
		
		print ( "STRING ==== " + gameManager.getSceneString());


		SqlManager sqlManager = GameObject.Find ("GameControl").GetComponent<SqlManager> ();
		if (buildingName == "")
			buildingName = "NotNamedBuilding";
		StartCoroutine(sqlManager.PostBuilding (buildingName, gameManager.getSceneString ()));
		print ("toto2");
		
		//PostObject (uid.ToString () + "." + "txt");

	}

}
