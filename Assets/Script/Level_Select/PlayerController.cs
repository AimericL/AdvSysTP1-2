using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_Speed = 10.0f;
    private Rigidbody2D m_Body;
    private Animator m_Animator;
    private float m_BoundLeft = -25;
    private float m_BoundRight = 100;

    void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Running();
        CheckBound();
    }

    private void CheckBound()
    {
        if (transform.position.x < m_BoundLeft)
        {
            transform.position = new Vector3(m_BoundLeft,transform.position.y,transform.position.z);
        }
        if (transform.position.x > m_BoundRight)
        {
            transform.position = new Vector3(m_BoundRight, transform.position.y, transform.position.z);
        }
    }

    private void Running()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        float XSpeed = HorizontalAxis * m_Speed;
        float YSpeed = m_Body.velocity.y;
        Vector2 velocity = new Vector2(XSpeed, YSpeed);
        m_Body.velocity = velocity;

        bool IsMoving = Mathf.Abs(m_Body.velocity.x) > Mathf.Epsilon;
        if (IsMoving)
        {
            m_Animator.SetBool("IsRunning", true);
            FlipPlayer();
        }
        else
        {
            m_Animator.SetBool("IsRunning", false);
        }
    }

    private void FlipPlayer()
    {
        Vector3 Scale = transform.localScale;
        Scale.x = Mathf.Sign(m_Body.velocity.x);
        transform.localScale = Scale;
    }
}
