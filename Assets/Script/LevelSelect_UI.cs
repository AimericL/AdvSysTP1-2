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

    private void Awake()
    {
        m_Player = GameObject.Find("Player").GetComponent<PlayerController>();
        m_Player.m_OnLevelTrigger = PlayerOnPortal;
        m_Player.m_OnLevelTriggerExit = PlayerExitPortal;
    }


    private void PlayerOnPortal(LevelsData data)
    {
        m_LevelName.text = data.Name;
        m_LevelStar.sprite = data.StarIcon[0];
        m_LevelDescription.text = data.DescriptonText[0];
        m_LevelPath = data.SceneName;
        m_LevelSelector.SetActive(true);
    }

    private void PlayerExitPortal(LevelsData data)
    {
        m_LevelSelector.SetActive(false);
    }

    public void OnStartLevel()
    {
        SceneManager.LoadScene(m_LevelPath);
    }
}
