using UnityEngine;
using System.Collections.Generic;

public class MainWindow : MonoBehaviour
{
    public GameObject m_creditsWindow;
    public GameObject m_desktopWindow;
    public GameObject m_helpWindow;

    void Start()
    {
        m_creditsWindow.SetActive(false);
        m_desktopWindow.SetActive(false);
        m_helpWindow.SetActive(false);

        Game.onGameFinished += OnGameFinished;
    }

	void OnGameFinished()
	{
        PlayerPrefs.DeleteKey(GlyphDictionary.RANDOM_SEED_KEY);

        m_creditsWindow.SetActive(true);
	}

    public void OnMinimize()
    {
        m_desktopWindow.SetActive(true);
    }

    public void OnHelp()
    {
        m_helpWindow.SetActive(true);
    }
}
