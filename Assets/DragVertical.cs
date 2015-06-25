using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class DragVertical : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 position;
	private Sprite sp;
	//public GameObject block;

	void Awake () { 

			DontDestroyOnLoad(this); 
			
	}
	
	void OnMouseDown() {

		print("MouseDown");
		position = gameObject.transform.position;
		print (position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//sp = Sprite.Create ();
		//Instantiate(block, transform.position, gameObject.transform.rotation);
		//sp.
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

	void OnMouseUp()
	{
		print ("mouseup");
	}
}