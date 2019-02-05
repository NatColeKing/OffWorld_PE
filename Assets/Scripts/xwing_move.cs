using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xwing_move : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += new Vector3(0, 0, -0.5f);
	}
}
