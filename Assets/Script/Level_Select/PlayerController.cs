using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_Speed = 10.0f;
    private Rigidbody2D m_Body;
    private Animator m_Animator;
    public event Action<LevelsData> m_OnLevelTrigger;
    public event Action m_OnLevelTriggerExit;

    void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Running();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelsData _data = collision.GetComponent<LevelSelection>().m_LevelData;
        m_OnLevelTrigger?.Invoke(_data);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_OnLevelTriggerExit?.Invoke();
    }
}
