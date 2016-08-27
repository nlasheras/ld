using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LetterPanelView : MonoBehaviour {

    public GameObject m_panel;
    public LetterBoxView m_prefab;

	void Start ()
    {
        m_letters = new List<LetterBoxView>();

        Rect parentRect = m_panel.GetComponent<RectTransform>().rect;
        int left = (int)(-parentRect.width / 2);
        int top = (int)(parentRect.height / 2);
        float currentX = left;
        float currentY = top;

        float itemWidth = m_prefab.GetComponent<RectTransform>().rect.width;
        float itemHeight = m_prefab.GetComponent<RectTransform>().rect.height;

	    for (char c = 'a'; c <= 'z'; ++c)
        {
            GameObject newObj = Instantiate(m_prefab.gameObject);
            string letter = c.ToString();
            newObj.name = "letterBox_" + letter;
            LetterBoxView lbv = newObj.GetComponent<LetterBoxView>();
            lbv.m_letter = letter;


            newObj.transform.SetParent(m_panel.transform);
            RectTransform newTransform = newObj.GetComponent<RectTransform>();
            newTransform.localPosition = new Vector2(currentX + itemWidth/2, currentY - itemHeight/2);

            currentX += itemWidth;

            if (currentX + itemWidth > parentRect.width/2)
            {
                currentX = left;
                currentY -= itemHeight;
            }

            m_letters.Add(lbv);
        }
        m_prefab.gameObject.SetActive(false);

        Game.onPlayerDictUpdated += OnPlayerDictUpdated;
	}
	
	void OnPlayerDictUpdated(GlyphDictionary dict)
    {
	    foreach (var lbv in m_letters)
        {
            Glyph g = dict.get(lbv.m_letter[0]);
            lbv.m_glyph.sprite = GlyphVisuals.Instance.GetVisual(g.VisualId);
        }
	}

    public LetterBoxView findLetterAtPos(Vector3 pos)
    {
        float maxDist = 50;
        foreach (var lbv in m_letters)
        {
            float dist = Vector3.Distance(pos, lbv.transform.position);
            if (dist < maxDist)
                return lbv;               
        }
        return null;
    }

    
    private List<LetterBoxView> m_letters;
}
