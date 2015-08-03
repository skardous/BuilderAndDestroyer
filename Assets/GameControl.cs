using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int nbCubes;
	public int currentLevel = 0;
	private GameObject[][] bricks;

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
		
	// Update is called once per frame
	void Update () {
	
	}
}
