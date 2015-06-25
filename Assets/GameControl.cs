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
		if (control == null) 
		{
			DontDestroyOnLoad(this); 
			control = this;
		} 
		else if (control != this) 
		{
			Destroy(gameObject);
		}
		bricksPerLevel.Add (new List<GameObject> ());
	}

	public void increaseLevel()
	{
		print ("Level Up");
		foreach (GameObject brick in bricksPerLevel[currentLevel]) {
			Color color = brick.GetComponent<SpriteRenderer>().color;
			color = new Color(color.r, color.g, color.b, .5f);
			brick.GetComponent<SpriteRenderer>().color = color;			
		}

		currentLevel++;

		if (bricksPerLevel.Count < currentLevel + 1)
			bricksPerLevel.Add (new List<GameObject> ());

		foreach (GameObject brick in bricksPerLevel[currentLevel]) {
			Color color = brick.GetComponent<SpriteRenderer>().color;
			color = new Color(color.r, color.g, color.b, 1.0f);
			brick.GetComponent<SpriteRenderer>().color = color;			
		}
	}

	public void decreaseLevel()
	{
		if (currentLevel > 0) {
			foreach (GameObject brick in bricksPerLevel[currentLevel]) {
				Color color = brick.GetComponent<SpriteRenderer>().color;
				color = new Color(color.r, color.g, color.b, .5f);
				brick.GetComponent<SpriteRenderer>().color = color;			
			}
			
			currentLevel--;
			
			if (bricksPerLevel.Count < currentLevel + 1)
				bricksPerLevel.Add (new List<GameObject> ());
			
			foreach (GameObject brick in bricksPerLevel[currentLevel]) {
				Color color = brick.GetComponent<SpriteRenderer>().color;
				color = new Color(color.r, color.g, color.b, 1.0f);
				brick.GetComponent<SpriteRenderer>().color = color;			
			}
		}
		
		
	}

	public void createBrick(GameObject brick)
	{
		print ("gamecontrol creates a brick");
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
