using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnBecameInvisible() {
		if (transform.position.y < 5) {
			rigidbody.AddForce (
				1750 * new Vector3 (
					Random.Range (-0.25f, 0.25f), 1, 0));
		}
	}
}
