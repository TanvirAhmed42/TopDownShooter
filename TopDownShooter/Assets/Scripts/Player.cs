using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : MonoBehaviour {

	public float moveSpeed = 5f;

	Camera mainCam;
	PlayerController controller;
	GunController gunController;

	void Start () {
		mainCam = Camera.main;
		controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
	}

	void Update () {
		//Move Input
		Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move (moveVelocity);

		//Look Input
		Ray ray = mainCam.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast (ray, out rayDistance)) {
			Vector3 point = ray.GetPoint (rayDistance);
			//Debug.DrawLine (ray.origin, point, Color.red);
			controller.LookAt (point);
		}

		//Weapon Input
		if (Input.GetMouseButton (0)) {
			gunController.Shoot ();
		}
	}
}
