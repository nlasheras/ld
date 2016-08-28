using UnityEngine;
using System.Collections.Generic;

public class MainWindow : MonoBehaviour
{
    public GameObject m_creditsWindow;

    void Start()
    {
        m_creditsWindow.SetActive(false);

        Game.onGameFinished += OnGameFinished;
    }

	void OnGameFinished()
	{
        PlayerPrefs.DeleteKey(GlyphDictionary.RANDOM_SEED_KEY);

        m_creditsWindow.SetActive(true);
	}
}
