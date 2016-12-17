using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AvatarMovement : MonoBehaviour
{
    private Rigidbody m_rb;
    private Rigidbody rb
    {
        get
        {
            if (m_rb == null)
            {
                m_rb = GetComponent<Rigidbody>();
                if (m_rb == null)
                {
                    Debug.Log("No Rigidbody component found! Creating new component...");
                    m_rb = this.gameObject.AddComponent<Rigidbody>();
                    m_rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }
            }
            return m_rb;
        }
    }

	// Update is called once per frame
	void Update ()
    {
#if UNITY_EDITOR
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
#elif UNITY_IOS || UNITY_ANDROID
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
#endif
        if (h != 0 || v != 0)
        {
            Move(h, v);
        }
	}

    private void Move(float h, float v)
    {
        Vector3 move = new Vector3(h * Time.deltaTime, 0, v * Time.deltaTime);
        Vector3 targetPosition = rb.position + move;
        rb.MovePosition(targetPosition);
    }
}
