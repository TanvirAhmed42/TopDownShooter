using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingEntity {

	NavMeshAgent agent;
	Transform target;

	protected override void Start ()
	{
		base.Start ();
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		StartCoroutine (UpdatePath ());
	}

	void Update () {
	}

	IEnumerator UpdatePath () {
		float refreshRate = .25f;

		while (target != null) {
			Vector3 targetPosition = new Vector3 (target.position.x, 0f, target.position.z);
			if (!dead) {
				agent.SetDestination (targetPosition);
			}

			yield return new WaitForSeconds (refreshRate);
		}
	}
}
