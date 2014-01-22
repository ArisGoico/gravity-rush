using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1f;

	// Use this for initialization
	void Start () {
		if (this.rigidbody == null) {
			Debug.LogError("The player needs to have a Rigidbody attached. Disabling.");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f));
	}
}
