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
            ret.Add(get(c));
        }
        return ret;
    }

    public Glyph get(char key)
    {
        if (m_translations.ContainsKey(key))
            return m_translations[key];
        else
            return m_translations[UNKNOWN_GLYPH_CHAR];
    }

    public bool hasGlyph(Glyph g)
    {
        return m_translations.ContainsValue(g);
    }

    public char getLetter(Glyph g)
    {
        foreach (var pair in m_translations)
        {
            if (pair.Value == g)
                return pair.Key;
        }
        UnityEngine.Debug.LogError("Dictionary doesn't has glyph " + g.VisualId.ToString());
        return UNKNOWN_GLYPH_CHAR;
    }

    public void set(char key, Glyph glyph)
    {
        if (m_translations.ContainsValue(glyph))
            m_translations.Remove(getLetter(glyph));
        m_translations[key] = glyph;
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
