using System.Collections.Generic;

public class Puzzle
{
    public Puzzle(PuzzleDefinition def)
	{
        Definition = def;
        Glyphs = Game.Instance.puzzleDict.toGlyphs(def.Answer);
	}

    public bool checkFinished(GlyphDictionary dict)
    {
        foreach (var glyph in Glyphs)
        {
            var playerGuess = dict.get(glyph.Letter);
            if (playerGuess.VisualId != glyph.VisualId)
                return false;
        }
        return true;
    }

    public List<Glyph> Glyphs { get; private set; }
    public PuzzleDefinition Definition { get; private set; }
}
