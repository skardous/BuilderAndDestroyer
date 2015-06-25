using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(BoxCollider2D))]

public class UpClick : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 position;
	
	void OnMouseDown() {
		GameControl.control.currentLevel++;
	}
	
	void OnMouseDrag()
	{
	}
}