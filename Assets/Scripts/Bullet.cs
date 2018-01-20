using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    [SerializeField]
    float m_speed = 10;
    Rigidbody2D m_rigidbody;

	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = new Vector2(0, m_speed);
        velocity = Quaternion.Inverse(transform.rotation) * velocity;
        m_rigidbody.velocity = velocity; 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
    }
}
