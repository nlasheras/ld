using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleView : MonoBehaviour
{
    public GameObject m_panel;
    public PuzzleLetterView m_prefab;

    public Button m_prevPuzzle;
    public Button m_nextPuzzle;

    public Text m_question;

    void Start()
    {
        Game game = Game.Instance;

        Game.onPuzzleChanged += OnPuzzleChanged;
        Game.onPlayerDictUpdated += OnPlayerDictUpdated;

        m_glyphs = new List<PuzzleLetterView>();

        game.InitPuzzles(); // TODO: find a better place for initialization!
    }

    void OnPuzzleChanged(Puzzle puzzle)
    {
        foreach (var glyph in m_glyphs)
        {
            Destroy(glyph.gameObject);
        }
        m_glyphs.Clear();

        m_prefab.gameObject.SetActive(true);

        m_question.text = puzzle.Definition.Question;

        float itemWidth = m_prefab.GetComponent<RectTransform>().rect.width;
        const float itemSeparationX = 8.0f;
        float panelWidth = m_panel.GetComponent<RectTransform>().rect.width;
        float answerWidth = puzzle.Glyphs.Count * itemWidth + (puzzle.Glyphs.Count - 1) * itemSeparationX;

        float offsetX = (panelWidth - answerWidth) * 0.5f;

        float currentX = -panelWidth / 2.0f + offsetX;
        float currentY = 0;
        int count = 0;
        foreach (var glyph in puzzle.Glyphs)
        {
            GameObject newObj = Instantiate(m_prefab.gameObject);

            newObj.name = "glyph_" + (count++).ToString();
            PuzzleLetterView plv = newObj.GetComponent<PuzzleLetterView>();
            LetterBoxView lbv = newObj.GetComponent<LetterBoxView>();

            plv.Init(glyph);

            newObj.transform.SetParent(m_panel.transform);
            RectTransform newTransform = newObj.GetComponent<RectTransform>();
            newTransform.localPosition = new Vector2(currentX + itemWidth * 0.5f, currentY);

            currentX += itemWidth + itemSeparationX;

            m_glyphs.Add(plv);
        }

        m_prefab.gameObject.SetActive(false);

        m_prevPuzzle.gameObject.SetActive(Game.Instance.CurrentPuzzleIndex > 0);
        m_nextPuzzle.gameObject.SetActive(Game.Instance.CurrentPuzzleIndex < Game.Instance.PuzzleCount-1);

        OnPlayerDictUpdated(Game.Instance.playerDict);
	}

	void OnPlayerDictUpdated(GlyphDictionary dict)
	{
        foreach (var glyph in m_glyphs)
        {
            glyph.UpdateWithDictionary(dict);
        }
	}

    public void ChangePuzzle(int direction)
    {
        Game game = Game.Instance;
        int newIndex = game.CurrentPuzzleIndex + direction;
        game.ShowPuzzle(newIndex);
    }

    private List<PuzzleLetterView> m_glyphs;

}
