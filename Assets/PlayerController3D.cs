using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    private float m_Speed = 10.0f;
    private Rigidbody m_PlayerRigidbody;
    void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        m_PlayerRigidbody.velocity = m_Speed;
    }
}
