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
        m_puzzles = new List<PuzzleDefinition>();
        m_puzzles.Add(new PuzzleDefinition("Oro parece, plata no es", "platano"));
        m_puzzles.Add(new PuzzleDefinition("Esto es muy guay", "perita"));
        m_puzzles[m_puzzles.Count - 1].UnlocksCount = 3;
        m_puzzles.Add(new PuzzleDefinition("It truly makes the most beautiful music", "silence"));

        m_unlockedCount = 2;

        ShowPuzzle(0);
    }

    public void ShowPuzzle(int index)
    {
        if (index >= 0 && index < m_puzzles.Count)
        {
            currentPuzzle = new Puzzle(m_puzzles[index]);
            CurrentPuzzleIndex = index;

            onPuzzleChanged(currentPuzzle);
        }
    }

    public int CurrentPuzzleIndex { get; private set; } 
    public int PuzzleCount { get { return m_unlockedCount; } }

    public void setPlayerGlyph(char letter, Glyph glyph)
    {
        playerDict.set(letter, glyph);

        onPlayerDictUpdated(playerDict);

        if (currentPuzzle.checkFinished(playerDict))
        {
            if (currentPuzzle.Definition.UnlocksCount > m_unlockedCount)
            {
                m_unlockedCount = currentPuzzle.Definition.UnlocksCount;

                // HACK: to update buttons
                onPuzzleChanged(currentPuzzle);
            }
        }
    }

    public GlyphDictionary playerDict { get; private set; }
    public GlyphDictionary puzzleDict { get; private set; }
    public Puzzle currentPuzzle { get; private set; }

    private List<PuzzleDefinition> m_puzzles;
    private int m_unlockedCount;
}
