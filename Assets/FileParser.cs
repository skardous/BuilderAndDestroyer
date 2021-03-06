﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;


public class FileParser : MonoBehaviour {

	public static FileParser parser;	

	public GameObject brickXToCreate;
	public GameObject brickYToCreate;

	private List<List<GameObject>> bricksPerLevel = new List<List<GameObject>> ();	

	void Awake () { 
		
		DontDestroyOnLoad(this); 
		parser = this;

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
		
		bricksPerLevel.Add (new List<GameObject> ());
	}

	public void parseData(string data)
	{
		//string[] levels = data.Split(new Char [] {']'});

		//GroupCollection levels = Regex.Match (data, @"\[([^]]*)\]").Groups;

		var levelPattern = @"\[(.*?)\]";
		//var query = "H1-receptor antagonist [HSA:3269] [PATH:hsa04080(3269)]";
		var levelMatches = Regex.Matches(data, levelPattern);

		int i = 0;
		foreach (Match lm in levelMatches) {
			string levelData = lm.Groups[1].ToString();;
			var brickSplitPattern = @"\{(.*?)\}";
			var brickMatches = Regex.Matches(levelData, brickSplitPattern);
			bricksPerLevel.Add (new List<GameObject> ());
			print(lm.Groups[1]);
			
			foreach (Match bm in brickMatches) {
				string brickText = bm.Groups[1].ToString();
				string[] brickData = brickText.Split(new Char [] {';'});
				print("on level "+i+ ": "+bm.Groups[1]);
				GameObject blockCreated = null;
				if (brickData[0].Contains ("2dBrickX")) {
					print ("create brick X in 3D");
					blockCreated = Instantiate(brickYToCreate, new Vector3(float.Parse(brickData[1]), float.Parse(brickData[2]), 0.0f),gameObject.transform.rotation) as GameObject;
				} else if (brickData[0].Contains ("2dBrickY")) {
					print ("create brick Y in 3D");					
					blockCreated = Instantiate(brickXToCreate, new Vector3(float.Parse(brickData[1]), float.Parse(brickData[2]), 0.0f), gameObject.transform.rotation) as GameObject;
				}
				bricksPerLevel[i].Add(blockCreated);
			}
			i++;
			
			
		}
		//print ("____ levels = ");
		/*for (int i = 0; i < levels.Length - 1; i++) {
			levels [i].Replace('[',' ');
			print ("[" + i + "] = " + levels [i]);
		}*/
	}

	public List<List<GameObject>> getBricksPerLevel()
	{
		return bricksPerLevel;
	}
}
