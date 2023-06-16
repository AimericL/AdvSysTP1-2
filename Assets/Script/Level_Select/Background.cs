using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float m_StartPosition;
    private float m_SpriteLenght;
    [Header("Background Speed")]
    [SerializeField] private float m_BackgroundSpeed;
   
    void Start()
    {
        m_StartPosition = transform.position.x;
        m_SpriteLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float _distance = Camera.main.transform.position.x * m_BackgroundSpeed;
        float _resetDistance = Camera.main.transform.position.x * (1 - m_BackgroundSpeed);

        transform.position = new Vector3(m_StartPosition + _distance, transform.position.y, transform.position.z);

        if (_resetDistance > m_StartPosition + m_SpriteLenght)
        {
            m_StartPosition += m_SpriteLenght;
        }
        else if (_resetDistance < m_StartPosition - m_SpriteLenght)
        {
            m_StartPosition -= m_SpriteLenght;
        }
    }
}
