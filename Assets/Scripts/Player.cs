using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShootingActor {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        HorizontalMove(Input.GetAxisRaw("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet(0);
        }
	}
}
