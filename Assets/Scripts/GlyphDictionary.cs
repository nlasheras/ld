using System.Collections.Generic;

using UnityEngine; 

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

        initSeed();

        // Generate a list of possible ids
        int id = 2;
        List<int> tmp = new List<int>();
        for (char c = 'a'; c <= 'z'; ++c)
        {
            tmp.Add(id++);
        }

        for (char c = 'a'; c <= 'z'; ++c)
        {
            int index = Random.Range(0, tmp.Count);
            int randomId = tmp[index];
            tmp.RemoveAt(index);

            dict.m_translations[c] = new Glyph(c, randomId);
        }

        return dict;
    }

    public static readonly string RANDOM_SEED_KEY = "RandomSeed";

    private static void initSeed()
    {
        int seed = 0;
        if (PlayerPrefs.HasKey(RANDOM_SEED_KEY))
        {
            seed = PlayerPrefs.GetInt(RANDOM_SEED_KEY);
        }
        else
        {
            System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            int epochSecs = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
            seed = epochSecs;
            PlayerPrefs.SetInt(RANDOM_SEED_KEY, seed);
        }

        Random.InitState(seed);
    }

}
