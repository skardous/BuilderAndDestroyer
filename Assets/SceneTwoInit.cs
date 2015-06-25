using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SceneTwoInit : MonoBehaviour {

	public GameObject brickXToCreate;
	public GameObject brickYToCreate;
	

	// Use this for initialization
	void Start () {
		GameControl gameManager = GameObject.Find("GameControl").GetComponent<GameControl>();

		List<List<GameObject>> bricksPerLevel = gameManager.getBricksPerLevel ();
		int i = 0;
		foreach (List<GameObject> level in bricksPerLevel) {
			i++;
			foreach (GameObject brick in level) {
				print (brick.name);
				if (brick.name.Contains("2dBrickX"))
				{
					Instantiate (
						brickXToCreate,
						new Vector3 ((brick.transform.position.x - 178)/20, i*0.29f, (brick.transform.position.y - 267)/20),
						brick.transform.rotation);
				}
				else if (brick.name.Contains("2dBrickY"))
				{
					Instantiate (
						brickYToCreate,
						new Vector3 ((brick.transform.position.x - 178)/20, i*0.29f, (brick.transform.position.y - 267)/20),
						brick.transform.rotation);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
