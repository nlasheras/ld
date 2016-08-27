using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LetterBoxView : MonoBehaviour {

    public string m_letter;

    public Text m_text;
    public Image m_glyph;

	void Start ()
    {
        m_text.text = m_letter;
	}
	
	void Update ()
    {
	
	}

    public void SetLetter(char letter)
    {
        m_letter = letter.ToString();
        m_text.text = m_letter;
    }
}
