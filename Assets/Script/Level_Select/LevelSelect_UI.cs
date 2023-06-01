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
    private LevelsData m_data;

    private void Awake()
    {
        m_Player = GameObject.Find("Player").GetComponent<PlayerController>();
        m_Player.m_OnLevelTrigger += PlayerOnPortal;
        m_Player.m_OnLevelTriggerExit += PlayerExitPortal;
    }

    private void PlayerOnPortal(LevelsData data)
    {
        m_data = data;
        m_LevelName.text = data.Name;
        m_LevelStar.sprite = data.StarIcon[0];
        m_IndexDes = 0;
        m_Lenght = data.DescriptonText.Count - 1;
        m_LevelDescription.text = "";
        m_TypeWritter = StartCoroutine(TypeText());
        m_LevelPath = data.SceneName;
        m_LevelSelector.SetActive(true);
    }

    private void PlayerExitPortal()
    {
        m_LevelSelector.SetActive(false);
        m_IndexDes = 0;
        StopCoroutine(m_TypeWritter);
        m_LevelDescription.text = "";
    }

    private IEnumerator TypeText()
    {
        foreach (char _char in m_data.DescriptonText[m_IndexDes].ToCharArray())
        {
            m_LevelDescription.text += _char;
            yield return new WaitForSeconds(0.2f);
        }
        m_LevelDescription.text = m_data.DescriptonText[m_IndexDes];

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
            m_LevelDescription.text = m_data.DescriptonText[m_IndexDes];
        }
    }
}
