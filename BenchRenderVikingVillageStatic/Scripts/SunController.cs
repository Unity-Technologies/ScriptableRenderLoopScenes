using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour
{
	public float dragSpeed = 1;
	bool dragging = false;
	Vector2 startPos = new Vector2();
	Quaternion quat = Quaternion.identity;
	float altitude = 0, azimuth = 0;
//	float oldPitch = 0, oldYaw = 0;
	private float lerp = 0;
	public Light controlled = null;
	private float lightIntensity = 0;
	void Start ()
	{
		lightIntensity = controlled.intensity;
		quat.eulerAngles = new Vector3(altitude, azimuth, 0);
		controlled.transform.rotation = quat;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		if(Input.GetMouseButtonDown(0))
		{
			startPos = Input.mousePosition;
			dragging = true;
			//store yaw and pitch
//			oldPitch = quat.eulerAngles.x;
//			oldYaw = quat.eulerAngles.y;
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			dragging = false;
		}
	}
	void FixedUpdate()
	{
		if(dragging)
		{

			azimuth += dragSpeed * (Input.mousePosition.x - startPos.x);
			altitude = Mathf.Min(Mathf.Max(altitude + dragSpeed * (Input.mousePosition.y - startPos.y), 15f), 360f-15f);
			altitude = Mathf.Min (altitude, 80f);
			startPos = Input.mousePosition;
			quat.eulerAngles = new Vector3(altitude, azimuth, 0);

			if (controlled)
			{
				//controlled.transform.rotation *= quat;
				//if(controlled.transform.rotation.eulerAngles[0] < 15)
				controlled.transform.rotation = quat;//.eulerAngles.Set(altitude, azimuth,0);
				//controlled.intensity = controlled.transform.eulerAngles[0]/360;
			}
//			lerp = 1;
		}
//		else
//		{
//			quat = Quaternion.Slerp(Quaternion.identity, quat, lerp);
//			lerp *= 0.5f;
//		}

	}
	// Update is called once per frame
	void LateUpdate ()
	{

	}
}
