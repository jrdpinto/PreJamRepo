using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : ShootingActor {
    InvaderHivemind hivemind;

	// Use this for initialization
	protected override void Start () {
        base.Start();

        hivemind = FindObjectOfType<InvaderHivemind>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
    }
}
