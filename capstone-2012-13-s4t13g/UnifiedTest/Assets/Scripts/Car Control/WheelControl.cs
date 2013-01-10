using UnityEngine;
using System.Collections;

public class WheelControl : MonoBehaviour {
	
	public WheelCollider affectedWheel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		double rotationSpeed = affectedWheel.rpm;
		float rotationAmount;
		rotationAmount = ((float)rotationSpeed / 60.0f) * Time.deltaTime;
		transform.RotateAroundLocal(-Vector3.left, rotationAmount);
		
		
		// now set the wheel rotation to the rotation of the collider combined with a new rotation value. This new value
		// is the rotation around the axle, and the rotation from steering input.
		
		if (affectedWheel.gameObject.name == "FrontLeftWheelCollider" )
		{
			transform.localRotation = Quaternion.Euler( transform.localRotation.x, 0 + affectedWheel.steerAngle , transform.localRotation.z );
		}
		else if (affectedWheel.gameObject.name == "FrontRightWheelCollider" )
		{
			transform.localRotation = Quaternion.Euler( transform.localRotation.x, 180 + affectedWheel.steerAngle , transform.localRotation.z );
		}
		
		//transform.localRotation *= Quaternion.Euler(  0, 0, affectedWheel.steerAngle );
		//Vector3 wheelAngle = transform.R;
		//wheelAngle = affectedWheel.steerAngle;
		//transform.localRotation = wheelAngle;
	}
}
