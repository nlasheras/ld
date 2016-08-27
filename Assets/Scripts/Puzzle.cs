using System.Collections.Generic;

public class Puzzle
{
    private string m_answer;

    public Puzzle(string answer)
	{
        m_answer = answer;

        glyphs = Game.Instance.puzzleDict.toGlyphs(answer);
	}

    public List<Glyph> glyphs { get; private set; }
}
