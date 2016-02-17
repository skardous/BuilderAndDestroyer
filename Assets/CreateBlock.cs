using UnityEngine;
using System.Collections;
using System;


public class CreateBlock : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 buttonPosition;
	private Vector3 touchPosition;	
	private Sprite sp;
	public GameObject blockToCreate;
	private GameObject blockCreated;

	void Update () 
	{
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];
//			//Create horizontal plane
//			Plane horPlane = new Plane(Vector3.up, Vector3.zero);
			
			//Gets the ray at position where the screen is touched
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			
			if (touch.phase == TouchPhase.Began) 
			{
				RaycastHit hit = new RaycastHit();

				buttonPosition = gameObject.transform.position;
				touchPosition = touch.position;
				
				print ("buttonPosition = " +buttonPosition);
				print ("touchPosition = " +touch.position);

				float distance = Mathf.Sqrt(Mathf.Pow((buttonPosition.x - touchPosition.x),2) + Mathf.Pow((buttonPosition.y - touchPosition.y),2));
				float size = gameObject.GetComponent<RectTransform>().localScale.x * 2;
				
				if (distance < size) 
				{
					Vector3 brickPosition = Camera.main.ScreenToWorldPoint(new Vector3((float)Math.Round(touch.position.x,1), (float)Math.Round(touch.position.y,1), screenPoint.z));
					brickPosition.z = 0.0f;
					print ("brickPosition = "+brickPosition);
					offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));
					//sp = Sprite.Create ();
					blockCreated = Instantiate(blockToCreate, brickPosition, gameObject.transform.rotation) as GameObject;


					print ("block creation... at position : " + brickPosition);
					
					GameControl gameManager = GameObject.Find("GameControl").GetComponent<GameControl>();
					gameManager.createBrick (blockCreated);
				}

//				if (Physics.Raycast(ray, out hit, maxPickingDistance)) 
//				{ 
//					pickedObject = hit.transform;
//					startPos = touch.position;
//				} 
//				else
//				{
//					pickedObject = null;
//				}
			} 
			else if (touch.phase == TouchPhase.Moved) 
			{
				print ("moving to touch.position : "+touch.position);
				if (blockCreated)
				{
					Vector3 curScreenPoint = new Vector3(touch.position.x, touch.position.y, 0.0f);
					Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
					curPosition.z = 0.0f;
					print ("curPosition = " + curPosition);
					blockCreated.transform.position = curPosition;
				}
			} 
			else if (touch.phase == TouchPhase.Ended) 
			{
				blockCreated = null;
				//pickedObject = null;
			}
		}
	}

	#if UNITY_EDITOR_WIN
	void OnMouseDown() {

		Vector3 brickPosition = Camera.main.ScreenToWorldPoint(new Vector3((float)Math.Round(Input.mousePosition.x,1), (float)Math.Round(Input.mousePosition.y,1), screenPoint.z));
		brickPosition.z = 0.0f;
		print ("brickPosition = "+brickPosition);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//sp = Sprite.Create ();
		blockCreated = Instantiate(blockToCreate, brickPosition, gameObject.transform.rotation) as GameObject;

		GameControl gameManager = GameObject.Find("GameControl").GetComponent<GameControl>();
		gameManager.createBrick (blockCreated);
		//sp.
	}
	
	void OnMouseDrag()
	{
		print ("mousedrag");
		Vector3 curScreenPoint = new Vector3((float)Math.Round(Input.mousePosition.x,0), (float)Math.Round(Input.mousePosition.y,0), screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + (new Vector3(0.0f, 0.0f, offset.z));
		blockCreated.transform.position = curPosition;
		print (curScreenPoint);
	}
	
	void OnMouseUp()
	{
		print ("mouseup");
	}

	#endif
}