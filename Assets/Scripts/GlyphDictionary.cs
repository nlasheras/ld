using System.Collections.Generic;

public class GlyphDictionary
{
    public readonly static char UNKNOWN_GLYPH_CHAR = '?';

    private Dictionary<char, Glyph> m_translations;

    public List<Glyph> toGlyphs(string text)
    {
        var ret = new List<Glyph>();
        foreach (char c in text)
        {
            if (m_translations.ContainsKey(c))
                ret.Add(m_translations[c]);
            else
                ret.Add(m_translations[UNKNOWN_GLYPH_CHAR]);
        }
        return ret;
    }

    private GlyphDictionary()
    {
        m_translations = new Dictionary<char, Glyph>();
        m_translations[UNKNOWN_GLYPH_CHAR] = new Glyph(UNKNOWN_GLYPH_CHAR, 0);
        m_translations[' '] = new Glyph(' ', 1);
    }

    public static GlyphDictionary createEmptyDictionary()
    {
        return new GlyphDictionary();
    }

    public static GlyphDictionary createRandomDictionary()
    {
        var dict = new GlyphDictionary();

        // TODO: shuffle glyphs!
        int id = 1;
        for (char c = 'a'; c <= 'z'; ++c)
        {
            dict.m_translations[c] = new Glyph(c, id++);
        }

        return dict;
    }

}
