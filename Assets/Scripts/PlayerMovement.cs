using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float m_speed = 5;
    Rigidbody2D m_rigidbody;

	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = m_rigidbody.velocity;
        velocity.x = Input.GetAxisRaw("Horizontal") * m_speed;
        m_rigidbody.velocity = velocity;
    }
}
