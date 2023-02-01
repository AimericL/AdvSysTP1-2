using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform m_Target;

    private void Start()
    {
        PlayerController Player = FindObjectOfType<PlayerController>();
        if (Player != null)
        {
            m_Target = Player.transform;
        }
    }

    private void Update()
    {
        if (m_Target != null)
        {
            Vector3 Position = m_Target.position;
            Position.y = transform.position.y;
            Position.z = transform.position.z;
            transform.position = Position;
        }
    }
}
