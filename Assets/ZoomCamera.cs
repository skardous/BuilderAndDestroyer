using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];


			
			if (touch.phase == TouchPhase.Began) 
			{

			} 
			else if (touch.phase == TouchPhase.Moved) 
			{
				print ("moving to touch.position : "+touch.position);
				
				Vector3 curScreenPoint = new Vector3(touch.position.x, touch.position.y, 0.0f);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
				curPosition.z = 0.0f;
				print ("CamPosition = " + curPosition);

				Vector3 camPosition = gameObject.transform.position;
				camPosition.x = curPosition.x;
				camPosition.y = curPosition.y;

				transform.position = new Vector3 (curPosition.x, curPosition.y, transform.position.z);
				
				

			} 
			else if (touch.phase == TouchPhase.Ended) 
			{
				//pickedObject = null;
			}
		}
	}
}
