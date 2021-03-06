﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3F;
	public float YOffset = 20f;
	private Vector3 velocity = Vector3.zero;

	void Update() 
	{
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, YOffset, 0));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
