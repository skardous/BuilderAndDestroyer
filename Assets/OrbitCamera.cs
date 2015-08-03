using UnityEngine;
using System.Collections;

/**
 * Change the camera into an orbital camera. An orbital is a camera
 * that can be rotated and that will automatically reorient itself to
 * always point to the target.
 * 
 * The orbit camera allow zooming and dezooming with the mouse wheel.
 * 
 * By clicking the mouse and dragging on the screen, the camera is moved. 
 * The angle of rotation  correspond to the distance the cursor travelled. 
 *  
 * The camera will keep the angular position when the button is pressed. To
 * rotate more, simply repress the mouse button et move the cursor.
 *
 * This script must be added on a camera object.
 *
 * @author Mentalogicus
 * @date 11-2011
 */
public class OrbitCamera : MonoBehaviour
{		
	public Transform target;
	public float distance= 10.0f;
	public int cameraSpeed= 5;

	public float xSpeed= 175.0f;
	public float ySpeed= 75.0f;

	public float pinchSpeed;
	private float lastDist = 0;
	private float curDist = 0;
	public int yMinLimit= 10; //Lowest vertical angle in respect with the target.
	public int yMaxLimit= 80;
	public float minDistance= 9.5f; //Min distance of the camera from the target
	public float maxDistance= 10.5f;

	private float x= 0.0f;
	private float y= 0.0f;

	private Touch touch;



	void  Start (){
		Vector3 angles= transform.eulerAngles;		
		x = angles.y;		
		y = angles.x;
	}



	void  Update (){
		
		if (target && GetComponent<Camera>()) {
			
			//Zooming with mouse
			
			distance += Input.GetAxis("Mouse ScrollWheel")*distance;
			
			distance = Mathf.Clamp(distance, minDistance, maxDistance);
			if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) 
				
			{					
				//One finger touch does orbit					
				touch = Input.GetTouch(0);					
				x += touch.deltaPosition.x * xSpeed * 0.002f;					
				y -= touch.deltaPosition.y * ySpeed * 0.002f;
				
			}
			
			if (Input.touchCount > 1 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
			{					
				//Two finger touch does pinch to zoom					
				var touch1 = Input.GetTouch(0);					
				var touch2 = Input.GetTouch(1);					
				curDist = Vector2.Distance(touch1.position, touch2.position);					
				if(curDist > lastDist)						
				{						
					distance += Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition)*pinchSpeed/10;						
				} 
				else
			{
					
					distance -= Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition)*pinchSpeed/10;
					
				}
				
				
				
				lastDist = curDist;
				
			}
			
			//Detect mouse drag;
			if (Application.platform == RuntimePlatform.WindowsPlayer ||
			    Application.platform == RuntimePlatform.WindowsEditor ||
			    Application.platform == RuntimePlatform.WindowsWebPlayer)
			{
					if(Input.GetMouseButton(0))   {
						
						
						
						x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
						
						y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;       
						
					}
			}
			
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			
			
			Quaternion rotation= Quaternion.Euler(y, x, 0);
			
			Vector3 vTemp = new Vector3(0.0f, 0.0f, -distance);
			
			Vector3 position= rotation * vTemp + target.position;
			
			
			
			transform.position = Vector3.Lerp (transform.position, position, cameraSpeed);
			
			transform.rotation = rotation;      
			
		}
		
	}



	static float  ClampAngle ( float angle ,   float min ,   float max  ){
		
		if (angle < -360)
			
			angle += 360;
		
		if (angle > 360)
			
			angle -= 360;
		
		return Mathf.Clamp (angle, min, max);
		
	}
		
		
		

	
} //End class