using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class SceneTwoInit : MonoBehaviour {

	public GameObject brickXToCreate;
	public GameObject brickYToCreate;
	public GameObject foundationXToCreate;
	public GameObject foundationYToCreate;

	private int buildingBricksNb = 0;
	private int destroyedBricksNb = 0;

	public Text scoreText;	
	public GameObject newHighScoreBtn;

	private List<GameObject> movableBricks3d = new List<GameObject>();

	// Use this for initialization
	void Start () {
		UpdateBricks ();
	}

	void UpdateBricks()
	{
		movableBricks3d.Clear ();
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
					if (i == 1)
					{
						if (brick.name.Contains ("2dBrickX")) {
							Object brickX3D = Instantiate (
								foundationXToCreate,
								new Vector3 ((brick.transform.position.x - 178) / 30, i * 0.29f, (brick.transform.position.y - 267) / 30),
								brick.transform.rotation) as GameObject;
							//bricks3d.Add(brickX3D);						
						} else if (brick.name.Contains ("2dBrickY")) {
							Object brickY3D = Instantiate (
								foundationYToCreate,
								new Vector3 ((brick.transform.position.x - 178) / 30, i * 0.29f, (brick.transform.position.y - 267) / 30),
								brick.transform.rotation) as GameObject;
							//bricks3d.Add(brickY3D);
						}
					}
					else
					{
						if (brick.name.Contains ("2dBrickX")) {
							GameObject brickX3D = Instantiate (
								brickXToCreate,
								new Vector3 ((brick.transform.position.x - 178) / 30, i * 0.29f, (brick.transform.position.y - 267) / 30),
								brick.transform.rotation) as GameObject;
							movableBricks3d.Add(brickX3D);						
						} else if (brick.name.Contains ("2dBrickY")) {
							GameObject brickY3D = Instantiate (
								brickYToCreate,
								new Vector3 ((brick.transform.position.x - 178) / 30, i * 0.29f, (brick.transform.position.y - 267) / 30),
								brick.transform.rotation) as GameObject;
							movableBricks3d.Add(brickY3D);
						}
					}
				}
			}
		}

		buildingBricksNb = movableBricks3d.Count;
	}

	private void UpdateScore(int score)
	{
		print ("update score");
		scoreText.text = score.ToString();

		GameControl gameControl = GameObject.Find ("GameControl").GetComponent<GameControl> ();
		
		if (score > gameControl.getBestScore ()) {
			newHighScoreBtn.SetActive(true);
			gameControl.setBestScore(score);
		}
	}

	
	// Update is called once per frame
	void Update () {
		List<GameObject> bricks3dToDestroy = new List<GameObject>();
		
		foreach (GameObject brick in movableBricks3d)
		{
			if (brick.transform.position.y < 0)
			{
				bricks3dToDestroy.Add(brick);
			}
		}

		foreach (GameObject brickToDestroy in bricks3dToDestroy)
		{
			Destroy(brickToDestroy);
			movableBricks3d.Remove(brickToDestroy);
			destroyedBricksNb++;
			
			double score = (100.0 * destroyedBricksNb) / buildingBricksNb;
			UpdateScore ((int)score);
		}
	}
}
