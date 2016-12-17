using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLook : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

	// Use this for initialization
	void Start ()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Align camera
        if (Application.isMobilePlatform)
        {
            transform.parent.transform.Rotate(Vector3.right, 90);

            // Enable gyro
            //Input.compensateSensors = true;
            Input.gyro.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (SystemInfo.supportsGyroscope)
        {
            Quaternion lookQuaternion = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
            mainCamera.transform.localRotation = lookQuaternion;
        }
	}
}
