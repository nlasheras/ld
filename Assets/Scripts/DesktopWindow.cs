using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DesktopWindow : MonoBehaviour
{
    public GameObject m_gameIconText;
    private bool m_gameIconEasterEggShown = false;

	void Start()
	{
        if (m_gameIconText != null)
           m_gameIconText.SetActive(false);
	}

	public void OnDecypherClick()
	{
        gameObject.SetActive(false);
	}

    private IEnumerator GameIconClick()
    {
        m_gameIconEasterEggShown = true;
        m_gameIconText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        m_gameIconText.SetActive(false);
    }

    public void OnGameIconClick()
    {
        if (!m_gameIconEasterEggShown && m_gameIconText != null)
            StartCoroutine(GameIconClick());
        else
            SoundManager.Instance.PlaySound(SoundEffect.OSError);

    }
}
