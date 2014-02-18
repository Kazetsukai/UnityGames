﻿using UnityEngine;
using System.Collections;

public class PlayerMouseControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(pos.x, pos.y + 0.7f);
	}
}
