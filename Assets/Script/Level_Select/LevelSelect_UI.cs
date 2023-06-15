using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect_UI : MonoBehaviour
{
    private PlayerController m_Player;
    [SerializeField] private GameObject m_LevelSelector;
    [SerializeField] private Text m_LevelName;
    [SerializeField] private Image m_LevelStar;
    [SerializeField] private Text m_LevelDescription;
    private string m_LevelPath;
    private int m_IndexDes;
    private int m_Lenght;
    private Coroutine m_TypeWritter;
    private LevelsData m_Data;

    private void Awake()
    {
        m_Player = GameObject.Find("Player").GetComponent<PlayerController>();
        m_Player.m_OnLevelTrigger += PlayerOnPortal;
        m_Player.m_OnLevelTriggerExit += PlayerExitPortal;
    }

    private void PlayerOnPortal(LevelsData data)
    {
        m_Data = data;
        if (m_Data != null)
        {
            m_LevelName.text = m_Data.Name;
            m_LevelStar.sprite = m_Data.StarIcon[0];
            m_IndexDes = 0;
            m_Lenght = m_Data.DescriptonText.Count - 1;
            m_LevelDescription.text = "";
            m_TypeWritter = StartCoroutine(TypeText());
            m_LevelPath = m_Data.SceneName;
            m_LevelSelector.SetActive(true);
        }
    }

    private void PlayerExitPortal()
    {
        m_LevelSelector.SetActive(false);
        m_IndexDes = 0;
        m_LevelDescription.text = "";
        if (m_TypeWritter != null)
        {
            StopCoroutine(m_TypeWritter);
        }
    }

    private IEnumerator TypeText()
    {
        foreach (char _char in m_Data.DescriptonText[m_IndexDes].ToCharArray())
        {
            m_LevelDescription.text += _char;
            yield return new WaitForSeconds(0.2f);
        }
        m_LevelDescription.text = m_Data.DescriptonText[m_IndexDes];

    }

    public void OnStartLevel()
    {
        SceneManager.LoadScene(m_LevelPath);
    }

    public void OnDescriptionTextButton()
    {
        StopCoroutine(m_TypeWritter);
        if ( m_IndexDes < m_Lenght)
        {
            m_IndexDes += 1;
            m_LevelDescription.text = "";  
            m_TypeWritter = StartCoroutine(TypeText());
        }
        else
        {
            m_LevelDescription.text = m_Data.DescriptonText[m_IndexDes];
        }
    }
}
