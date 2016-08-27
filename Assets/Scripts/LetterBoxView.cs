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
        //m_glyph.enabled = false;
	}
	
	void Update ()
    {
	
	}
}
