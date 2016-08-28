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

        m_puzzles.Add(new PuzzleDefinition("I saw here there for the first time", "nile"));
        m_puzzles.Add(new PuzzleDefinition("She was a beautiful gazelle, destined to end with a", "lion"));
        m_puzzles.Add(new PuzzleDefinition("But almost a kid, I didn't understand ", "love"));
        m_puzzles.Add(new PuzzleDefinition("Whould she mind?", "slave"));
        m_unlockedCount = m_puzzles.Count;
        m_puzzles[m_puzzles.Count - 1].UnlocksCount = 6;
        m_puzzles.Add(new PuzzleDefinition("I was close to the lion, building his final place", "mausoleum"));
        m_puzzles.Add(new PuzzleDefinition("With the time I had left I only had one option", "choosedeath"));
        m_puzzles[m_puzzles.Count - 1].UnlocksCount = 8;
        m_puzzles.Add(new PuzzleDefinition("I never spoke to her before, so my first words to her were my lasts", "papyrus"));
        m_puzzles.Add(new PuzzleDefinition("So, with that in mind what else could I ask but", "forgiveness"));
        m_puzzles[m_puzzles.Count - 1].UnlocksCount = 9;
        m_puzzles.Add(new PuzzleDefinition("This was the story of the digger and Delila", "thankyou"));

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

                SoundManager.Instance.PlaySound(SoundEffect.UnlockPuzzles);

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
