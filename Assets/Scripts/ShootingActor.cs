using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootingActor : MonoBehaviour {
    [SerializeField]
    float m_speed = 5;
    protected Rigidbody2D m_rigidbody;

    [SerializeField]
    GameObject m_bullet;

    // Use this for initialization
    virtual protected void Start()
    {
        m_bullet = GameObject.Instantiate(m_bullet);
        m_bullet.transform.parent = transform;
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ShootBullet(float eularAngle)
    {
        if (m_bullet.activeSelf)
            return;

        m_bullet.transform.localPosition = Vector2.zero;
        m_bullet.transform.rotation = Quaternion.Euler(0, 0, eularAngle);
        m_bullet.SetActive(true);
    }

    public void HorizontalMove(float input)
    {
        Vector2 velocity = m_rigidbody.velocity;
        velocity.x = input * m_speed;
        m_rigidbody.velocity = velocity;
    }

}
