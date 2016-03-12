using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int currentScore = 0; //percent
	public int bestScore = 0;
	public int id = 0;	
	public int currentLevel = 0;
	private GameObject[][] bricks;

	public GameObject brickX2DToCreate;
	public GameObject brickY2DToCreate;

	private List<List<GameObject>> bricksPerLevel = new List<List<GameObject>>();

	void Awake () { 

			DontDestroyOnLoad(this); 
			control = this;

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

		bricksPerLevel.Add (new List<GameObject> ());
	}

	public void increaseLevel()
	{
		print ("increaseLevel");
		foreach (GameObject brick in bricksPerLevel[currentLevel]) {
			setBrickOpacityTo(brick, .25f);		
						
		}

		currentLevel++;

		if (bricksPerLevel.Count < currentLevel + 1)
			bricksPerLevel.Add (new List<GameObject> ());

		foreach (GameObject brick in bricksPerLevel[currentLevel]) {
			setBrickOpacityTo(brick, 1.0f);		
		}
	}

	public void decreaseLevel()
	{
		print ("decreaseLevel");
		
		if (currentLevel > 0) {
			foreach (GameObject brick in bricksPerLevel[currentLevel]) {
			setBrickOpacityTo(brick, .25f);		
						
			}
			
			currentLevel--;
			
			if (bricksPerLevel.Count < currentLevel + 1)
				bricksPerLevel.Add (new List<GameObject> ());
			
			foreach (GameObject brick in bricksPerLevel[currentLevel]) {
			setBrickOpacityTo(brick, 1.0f);		
						
			}
		}	
	}

	private void setBrickOpacityTo (GameObject brick, float opacity)
	{
		Color color = brick.GetComponent<SpriteRenderer>().color;
		color = new Color(color.r, color.g, color.b, opacity);
		brick.GetComponent<SpriteRenderer>().color = color;	
	}

	public string getSceneString()
	{
		string res = "";
		foreach (List<GameObject> bricks in bricksPerLevel) {
			res = res + "[";
			foreach (GameObject brick in bricks) {
				res = res + "{"+ brick.name + ";" + brick.transform.position.x + ";" + brick.transform.position.y + "}";
			}
			res = res + "]";
			
		}
		return res;

	}

	public void createBrick(GameObject brick)
	{
		print ("gamecontrol creates a brick");
		if (bricksPerLevel.Count < currentLevel + 1)
			bricksPerLevel.Add (new List<GameObject> ());
		bricksPerLevel[currentLevel].Add(brick);
		int i = 0;
		foreach (List<GameObject> list in bricksPerLevel) {
			i++;
			print ("there are " + list.Count + " elements in level " +i);
		}
	}

	public List<List<GameObject>> getBricksPerLevel()
	{
		return bricksPerLevel;
	}

	public List<GameObject> getCurrentLevelBricks()
	{
		return bricksPerLevel[currentLevel];
	}

	public void parseData(string data)
	{
		//string[] levels = data.Split(new Char [] {']'});
		
		//GroupCollection levels = Regex.Match (data, @"\[([^]]*)\]").Groups;
		
		var levelPattern = @"\[(.*?)\]";
		//var query = "H1-receptor antagonist [HSA:3269] [PATH:hsa04080(3269)]";
		var levelMatches = Regex.Matches (data, levelPattern);
		
		int i = 0;
		foreach (Match lm in levelMatches) {
			string levelData = lm.Groups [1].ToString ();

			var brickSplitPattern = @"\{(.*?)\}";
			var brickMatches = Regex.Matches (levelData, brickSplitPattern);
			bricksPerLevel.Add (new List<GameObject> ());
			print (lm.Groups [1]);
			
			foreach (Match bm in brickMatches) {
				string brickText = bm.Groups [1].ToString ();
				string[] brickData = brickText.Split (new Char [] {';'});
				print ("on level " + i + ": " + bm.Groups [1]);
				GameObject blockCreated = null;
				if (brickData [0].Contains ("2dBrickX")) {
					print ("create brick X in 3D");
					blockCreated = Instantiate (brickX2DToCreate, new Vector3 (float.Parse (brickData [1]), float.Parse (brickData [2]), 0.0f), gameObject.transform.rotation) as GameObject;
				} else if (brickData [0].Contains ("2dBrickY")) {
					print ("create brick Y in 3D");					
					blockCreated = Instantiate (brickY2DToCreate, new Vector3 (float.Parse (brickData [1]), float.Parse (brickData [2]), 0.0f), gameObject.transform.rotation) as GameObject;
				}
				bricksPerLevel [i].Add (blockCreated);
			}
			i++;
			
			
		}
	}

	public void setBestScore(int score)
	{
		bestScore = score;
	}

	public void setId(int setid)
	{
		id = setid;
	}

	public void setCurrentLevel(int level)
	{
		currentLevel = level;
	}

	public int getBestScore()
	{
		return bestScore;
	}

	public int getId()
	{
		return id;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
