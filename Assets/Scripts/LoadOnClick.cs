using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;


public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int level)
	{
		Application.LoadLevel(level);
		if ((GameObject.Find ("GameControl") || GameObject.Find ("FileParser")) 
		    && (level == 0 || (GameObject.Find ("FileParser") && level == 3))) {

			List<List<GameObject>> bricksPerLevel = new List<List<GameObject>>();

			if (GameObject.Find ("FileParser"))
			{
				FileParser fileParser = GameObject.Find ("FileParser").GetComponent<FileParser> ();		
				bricksPerLevel = fileParser.getBricksPerLevel ();		
			}
			else		
			{
				GameControl gameControl = GameObject.Find ("GameControl").GetComponent<GameControl> ();
				bricksPerLevel = gameControl.getBricksPerLevel ();	
			}

			int i = 0;
			foreach (List<GameObject> l in bricksPerLevel) {
				i++;
				foreach (GameObject brick in l) {
					print (brick.name);
					Destroy(brick);
				}
			}

			print ("CLEAR !!!!!!!!!!!!");
			bricksPerLevel.Clear();
			
		}
	}

	public void DisplayPanel(GameObject panel)
	{
		//GameObject panel = GameObject.Find ("Panel");
		panel.SetActive (!panel.activeSelf);
		
	}

}
