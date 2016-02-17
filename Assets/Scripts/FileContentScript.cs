using UnityEngine;
using System.Collections;
using System;

public class FileContentScript : MonoBehaviour {

	private string bricksData = "";
	private string bestScoreData = "";
	private string id = "";
	
	public void setId(string data)
	{
		id = data;
	}

	public void setBricksData(string data)
	{
		bricksData = data;
	}

	public void setBestScoreData(string data)
	{
		bestScoreData = data;
	}

	public void parse()
	{
		print ("PARSE !");
		
		GameControl gameControl = GameObject.Find ("GameControl").GetComponent<GameControl> ();
		gameControl.parseData (bricksData);
		print ("PARSE1 !" + bestScoreData);
		
		gameControl.setBestScore ((int)float.Parse(bestScoreData));
		print ("PARSE 2!" + id);
		
		gameControl.setId ((int)float.Parse(id));
		
	}


}
