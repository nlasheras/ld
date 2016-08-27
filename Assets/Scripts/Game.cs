using System.Collections.Generic;

public class Game
{
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

    public void InitPuzzle()
    {
        currentPuzzle = new Puzzle("foobar");
    }

    public GlyphDictionary playerDict { get; private set; }
    public GlyphDictionary puzzleDict { get; private set; }
    public Puzzle currentPuzzle { get; private set; }
}
