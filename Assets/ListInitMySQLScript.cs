using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ListInitMySQLScript : MonoBehaviour {

	private	string list = "";
	public GameObject panelPrefab;

	private void UpdateList()
	{
		print ("_________________1.5__________________");
		bool requesting = true;
		SqlManager sqlManager = GameObject.Find ("ListInitScript").GetComponent<SqlManager> ();
		StartCoroutine(sqlManager.GetBuildings (list, fillList));
	}

	private void fillList(string listString)
	{
		print ("listString = " + listString);
		string[] buildings = listString.Split (new Char [] {'\n'});

		GameObject buildingsList = GameObject.Find ("BuildingsList");
		GameObject listItem;
		print ("length = " +buildings.Length);

		for (int i = 1; i < buildings.Length - 1; i++) {
			listItem = Instantiate(panelPrefab) as GameObject;
			listItem.transform.SetParent(buildingsList.transform);
			listItem.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			FileContentScript fileScript = listItem.GetComponent<FileContentScript>();
			string fileData = buildings[i].Split(new Char [] {'\t'})[1];
			fileScript.setFileData(fileData);
			listItem.GetComponentInChildren<Text>().text = buildings[i].Split(new Char [] {'\t'})[0];
		}
	}
	
	// Use this for initialization
	void Start () {
		print ("_________________1__________________");
			
		UpdateList();

		print ("________________2___________________");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
