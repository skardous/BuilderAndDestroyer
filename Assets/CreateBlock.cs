using UnityEngine;
using System.Collections;

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
				//touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));
				touchPosition = touch.position;
				
				print ("buttonPosition = " +buttonPosition);
				print ("touchPosition = " +touch.position);

				float distance = Mathf.Sqrt(Mathf.Pow((buttonPosition.x - touchPosition.x),2) + Mathf.Pow((buttonPosition.y - touchPosition.y),2));
				float size = gameObject.GetComponent<RectTransform>().localScale.x * 2;
				print ("distance Test = " + distance);
				print ("size  Test = " + size);
				
				if (distance < size) 
				{
					Vector3 toto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));
					toto.z = 0.0f;
					print ("toto = "+toto);
					offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));
					//sp = Sprite.Create ();
					blockCreated = Instantiate(blockToCreate, toto, gameObject.transform.rotation) as GameObject;


					print ("block creation... at position : " + toto);
					
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
//				if (pickedObject != null) 
//				{
//					float distance1 = 0f;
//					if (horPlane.Raycast(ray, out distance1))
//					{
//						pickedObject.transform.position = ray.GetPoint(distance1);
//					}
//				}
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
		
		print("MouseDown");
		buttonPosition = gameObject.transform.position;
		print (buttonPosition);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//sp = Sprite.Create ();
		blockCreated = Instantiate(blockToCreate, transform.position, gameObject.transform.rotation) as GameObject;

		print ("block creation... (button)");

		GameControl gameManager = GameObject.Find("GameControl").GetComponent<GameControl>();
		gameManager.createBrick (blockCreated);
		//sp.
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		blockCreated.transform.position = curPosition;
	}
	
	void OnMouseUp()
	{
		print ("mouseup");
	}

	#endif
}