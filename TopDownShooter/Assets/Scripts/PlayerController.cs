﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	Rigidbody myRigidbody;

	Vector3 velocity;

	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
	}

	public void Move (Vector3 _velocity) {
		velocity = _velocity;
	}

	public void LookAt (Vector3 lookPoint) {
		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
		transform.LookAt (heightCorrectedPoint);
	}
}
