using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class CreditsWindow : MonoBehaviour
{
    public Text m_textField;

    [Multiline]
    public string m_credits;

    public int m_speed = 600;

	void OnEnable()
	{
        m_textField.text = "";
        m_elapsedTime = 0.0f;
	}

	void Update()
	{
        if (!gameObject.activeSelf)
            return;

        m_elapsedTime += Time.deltaTime;

        float charTime = 60.0f / m_speed;

        int numChars = (int)Mathf.Min(m_elapsedTime / charTime, m_credits.Length);

        string subStr = m_credits.Substring(0, numChars);

        m_textField.text = subStr;
	}

    private float m_elapsedTime;
}
