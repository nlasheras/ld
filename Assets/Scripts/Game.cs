using System.Collections.Generic;

public class Game
{
    public delegate void OnPlayerDictUpdated(GlyphDictionary dict);
    public static event OnPlayerDictUpdated onPlayerDictUpdated;

    public delegate void OnPuzzleChanged(Puzzle puzzle);
    public static event OnPuzzleChanged onPuzzleChanged;

    // Singleton implementation
    private static Game sm_instance;
    public static Game Instance
    {
        get 
        { 
            if (sm_instance == null)
                sm_instance = new Game();
            return sm_instance;
        }    
    }

    private Game()
    {
        playerDict = GlyphDictionary.createEmptyDictionary();
        puzzleDict = GlyphDictionary.createRandomDictionary();
    }

    public void InitPuzzles()
    {
        m_puzzleAnswers = new List<string>();
        m_puzzleAnswers.Add("foobar");
        m_puzzleAnswers.Add("zanguango");
        m_puzzleAnswers.Add("nacho");
        m_puzzleAnswers.Add("siisbai");
        m_puzzleAnswers.Add("perita");

        ShowPuzzle(0);
    }

    public void ShowPuzzle(int index)
    {
        if (index >= 0 && index < m_puzzleAnswers.Count)
        {
            currentPuzzle = new Puzzle(m_puzzleAnswers[index]);
            CurrentPuzzleIndex = index;

            onPuzzleChanged(currentPuzzle);
        }
    }

    public int CurrentPuzzleIndex { get; private set; } 
    public int PuzzleCount { get { return m_puzzleAnswers.Count; } }

    public void setPlayerGlyph(char letter, Glyph glyph)
    {
        playerDict.set(letter, glyph);

        onPlayerDictUpdated(playerDict);
    }

    public GlyphDictionary playerDict { get; private set; }
    public GlyphDictionary puzzleDict { get; private set; }
    public Puzzle currentPuzzle { get; private set; }

    private List<string> m_puzzleAnswers;
}
