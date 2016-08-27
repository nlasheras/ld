using UnityEngine;

public class PuzzleLetterView : MonoBehaviour
{
    public LetterPanelView m_letterPanel;

	void Start()
    {
        m_startPosition = transform.position;
	}

    public void Init(Glyph glyph)
    {
        m_glyph = glyph;

        LetterBoxView lbv = GetComponent<LetterBoxView>();
        lbv.SetLetter(GlyphDictionary.UNKNOWN_GLYPH_CHAR);

        lbv.m_glyph.sprite = GlyphVisuals.Instance.GetVisual(glyph.VisualId);
    }

    public void UpdateWithDictionary(GlyphDictionary dict)
    {
        LetterBoxView lbv = GetComponent<LetterBoxView>();
        if (dict.hasGlyph(m_glyph))
        {
            char letter = dict.getLetter(m_glyph);
            lbv.SetLetter(letter);
        }
        else
            lbv.SetLetter(GlyphDictionary.UNKNOWN_GLYPH_CHAR);
            
    }
	
    public void OnPointerDown()
    {
    }

    public void OnPointerUp()
    {
        LetterBoxView lbv = GetComponent<LetterBoxView>();
        LetterBoxView letter = m_letterPanel.findLetterAtPos(lbv.m_glyph.transform.position);
        if (letter)
        {
            Game.Instance.setPlayerGlyph(letter.m_letter[0], m_glyph);
        }
        lbv.m_glyph.transform.position = m_startPosition;
    }

    public void OnDrag()
    {
        LetterBoxView lbv = GetComponent<LetterBoxView>();
        lbv.m_glyph.transform.position = Input.mousePosition;
    }

    private Vector3 m_startPosition;
    private Glyph m_glyph;
}
