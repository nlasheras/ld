using UnityEngine;
using System.Collections;

public class PuzzleLetterView : MonoBehaviour {

    Vector3 m_startPosition;

    public LetterPanelView m_letterPanel;
    
	void Start () {
        m_startPosition = transform.position;
	}
	
	void Update () {
	
	}

    public void OnPointerDown()
    {
        Debug.Log("mouse down");
    }

    public void OnPointerUp()
    {
        LetterBoxView letter = m_letterPanel.findLetterAtPos(transform.position);
        if (letter)
        {
            GetComponent<LetterBoxView>().m_letter = letter.m_letter;
            GetComponent<LetterBoxView>().m_text.text = letter.m_letter; // HACK
        }

        Debug.Log("mouse down");
        transform.position = m_startPosition;
    }

    public void OnDrag()
    {
        transform.position = Input.mousePosition;
    }
}
