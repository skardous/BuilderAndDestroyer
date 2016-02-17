using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ListInitMySQLScript : MonoBehaviour {

	private	string list = "";
	public GameObject panelPrefab;

	private int currentPage = 1;

	public InputField searchField;

	public void UpdateList()
	{
		bool requesting = true;
		Transform buildingsList = GameObject.Find ("BuildingsList").transform;
		foreach(Transform child in buildingsList) {

			Destroy(child.gameObject);
		}
		
		SqlManager sqlManager = GameObject.Find ("ListInitScript").GetComponent<SqlManager> ();
		StartCoroutine(sqlManager.GetBuildings (list, currentPage, fillList, searchField.text));
	}

	private void fillList(string listString)
	{
		string[] buildings = listString.Split (new Char [] {'\n'});

		GameObject buildingsList = GameObject.Find ("BuildingsList");
		GameObject listItem;

		for (int i = 1; i < buildings.Length - 1; i++) {
			listItem = Instantiate(panelPrefab) as GameObject;
			listItem.transform.SetParent(buildingsList.transform);
			listItem.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			FileContentScript fileScript = listItem.GetComponent<FileContentScript>();
			string fileData = buildings[i].Split(new Char [] {'\t'})[2];
			fileScript.setBricksData(fileData);
			string bestscore = buildings[i].Split(new Char [] {'\t'})[3];
			string bestChallenger = buildings[i].Split(new Char [] {'\t'})[4];
			
			//print ("bestscore = " +bestscore);
			fileScript.setBestScoreData(bestscore);
			string id = buildings[i].Split(new Char [] {'\t'})[0];
			fileScript.setId(id);
			
			listItem.transform.FindChild("buildingNameText").GetComponent<Text>().text = buildings[i].Split(new Char [] {'\t'})[1];
			listItem.transform.FindChild("buildingBestScoreText").GetComponent<Text>().text = bestscore;
			listItem.transform.FindChild("buildingBestChallengerText").GetComponent<Text>().text = bestChallenger;
			
			
		}
	}

	public void incrementPage()
	{
		currentPage++;
	}

	public void decrementPage()
	{
		currentPage--;
	}
	
	// Use this for initialization
	void Start () {
		UpdateList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
