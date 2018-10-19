using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	float speed = 10f;

	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	public void SetSpeed (float _speed) {
		speed = _speed;
	}
}
