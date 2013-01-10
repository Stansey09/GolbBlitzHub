using UnityEngine;
using System.Collections;

public class StephenCarController : MonoBehaviour {

    public WheelCollider FrontLeftWheel;
    public WheelCollider FrontRightWheel;
    public WheelCollider BackLeftWheel;
    public WheelCollider BackRightWheel;

    public float topSpeed = 50.0f;
    public float torque = 600.0f;
	
	public float effectiveTopSpeed = 50.0f;
    public float effectiveTorque = 600.0f;

    public float FRrpm;
    public float FLrpm;
    public float velocity;
	
	public float flipTimer;
	
	public bool isGrounded;
	
	//public float steerAmount;
	public float maxSteerAngle = 15;
	//private float steerPerSecond;
	
	
	public double boostTimer = 0;
	public bool boostActive = false;


	// Use this for initialization
	void Start () {
        Vector3 CoM = rigidbody.centerOfMass;
        CoM.y = -0.7f;
        rigidbody.centerOfMass = CoM;
		effectiveTopSpeed = topSpeed;
		effectiveTorque = torque;
		flipTimer = 0.0f;
		
		ParticleSystem system = gameObject.GetComponentInChildren<ParticleSystem>();
		system.enableEmission = false;
		
		//steerPerSecond = maxSteerAngle / 0.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		flipTimer += Time.deltaTime; 
		checkIfGrounded();
		
		
		boostTimer += Time.deltaTime;
		if (boostActive)
		{
			if (boostTimer > 1)
			{
				deactivateBoost();
			}
		}
		
        velocity = rigidbody.velocity.magnitude;
        if (velocity > effectiveTopSpeed)
        {
            Vector3 vel = rigidbody.velocity;
            rigidbody.velocity = vel.normalized * topSpeed;
        }
		

        FRrpm = FrontRightWheel.rpm;
        FLrpm = FrontLeftWheel.rpm;
		
		if (gameObject.name == "Player01")
		{
       		FrontLeftWheel.motorTorque = effectiveTorque * Input.GetAxis("P1Vertical");
        	FrontRightWheel.motorTorque = effectiveTorque * Input.GetAxis("P1Vertical");

       	 	FrontLeftWheel.steerAngle = maxSteerAngle * Input.GetAxis("P1Horizontal");
       		FrontRightWheel.steerAngle = maxSteerAngle * Input.GetAxis("P1Horizontal");
			
			
		}
		else if (gameObject.name == "Player02")
		{
       		FrontLeftWheel.motorTorque = effectiveTorque * Input.GetAxis("P2Vertical");
        	FrontRightWheel.motorTorque = effectiveTorque * Input.GetAxis("P2Vertical");

       	 	FrontLeftWheel.steerAngle = maxSteerAngle * Input.GetAxis("P2Horizontal");
       		FrontRightWheel.steerAngle = maxSteerAngle * Input.GetAxis("P2Horizontal");
	
		}
		else if (gameObject.name == "Player03")
		{
       		FrontLeftWheel.motorTorque = effectiveTorque * Input.GetAxis("P3Vertical");
        	FrontRightWheel.motorTorque = effectiveTorque * Input.GetAxis("P3Vertical");

       	 	FrontLeftWheel.steerAngle = maxSteerAngle * Input.GetAxis("P3Horizontal");
       		FrontRightWheel.steerAngle = maxSteerAngle * Input.GetAxis("P3Horizontal");
	
		}
		else if (gameObject.name == "Player04")
		{
       		FrontLeftWheel.motorTorque = effectiveTorque * Input.GetAxis("P4Vertical");
        	FrontRightWheel.motorTorque = effectiveTorque * Input.GetAxis("P4Vertical");

       	 	FrontLeftWheel.steerAngle = maxSteerAngle * Input.GetAxis("P4Horizontal");
       		FrontRightWheel.steerAngle = maxSteerAngle * Input.GetAxis("P4Horizontal");
	
		}
		

        /*FrontLeftWheel.motorTorque = effectiveTorque * Input.GetAxis("Vertical");
        FrontRightWheel.motorTorque = effectiveTorque * Input.GetAxis("Vertical");

        FrontLeftWheel.steerAngle = 10 * Input.GetAxis("Horizontal");
        FrontRightWheel.steerAngle = 10 * Input.GetAxis("Horizontal");*/
	}
	
	public void activateBoost()
	{
		boostTimer = 0;
		effectiveTopSpeed = topSpeed * 1.5f;
		effectiveTorque = torque * 5.5f;
		boostActive = true;
		ParticleSystem system = gameObject.GetComponentInChildren<ParticleSystem>();
		system.enableEmission = true;
	}
	
	public void deactivateBoost()
	{
		boostActive = false;
		effectiveTopSpeed = topSpeed;
		effectiveTorque = torque;
		ParticleSystem system = gameObject.GetComponentInChildren<ParticleSystem>();
		system.enableEmission = false;
	}
	
	public void checkIfGrounded()
	{
		
		if ((BackRightWheel.isGrounded) && (BackLeftWheel.isGrounded)&& (FrontLeftWheel.isGrounded) && (FrontRightWheel.isGrounded))
		{
			isGrounded = true;
			flipTimer = 0;
		}
		else
		{
			isGrounded = false;	
		}
		
		if (velocity > 5)
		{
			flipTimer = 0;	
		}
		
		if (flipTimer > 1.5)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0.0f);

		}
			
		
	}
}
