using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SceneTwoInit : MonoBehaviour {

	public GameObject brickXToCreate;
	public GameObject brickYToCreate;

	private List<Object> bricks3d = new List<Object>();

	// Use this for initialization
	void Start () {
		UpdateBricks ();
	}

	void UpdateBricks()
	{
		bricks3d.Clear ();
		GenerateBricks ();
	}

	void GenerateBricks()
	{
		if (GameObject.Find ("GameControl") || GameObject.Find ("FileParser")) {
			List<List<GameObject>> bricksPerLevel;
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
			int t = 0;
			
			foreach (List<GameObject> list in bricksPerLevel) {
				t++;
				print ("there are " + list.Count + " elements in level " +t);
			}
			
			//List<List<GameObject>> bricksPerLevel = gameManager.getBricksPerLevel ();
			int i = 0;
			foreach (List<GameObject> level in bricksPerLevel) {
				i++;
				foreach (GameObject brick in level) {
					print (brick.name);
					if (brick.name.Contains ("2dBrickX")) {
						Object brickX3D = Instantiate (
							brickXToCreate,
							new Vector3 ((brick.transform.position.x - 178) / 30, i * 0.29f, (brick.transform.position.y - 267) / 30),
							brick.transform.rotation);
						bricks3d.Add(brickX3D);						
					} else if (brick.name.Contains ("2dBrickY")) {
						Object brickY3D = Instantiate (
							brickYToCreate,
							new Vector3 ((brick.transform.position.x - 178) / 30, i * 0.29f, (brick.transform.position.y - 267) / 30),
							brick.transform.rotation);
						bricks3d.Add(brickY3D);
					}
				}
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
