using UnityEngine;
using System.Collections;

public class DestructionSpecific : MonoBehaviour {

	public GameObject hideOnDestruction1;
	public GameObject hideOnDestruction2;
	public GameObject triggerable;
	
	

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("FileParser")) {
			hideOnDestruction1.SetActive(false);
			hideOnDestruction2.SetActive(false);			
		}
		if (GameObject.Find ("GameControler")) {
			triggerable.SetActive(false);						
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
