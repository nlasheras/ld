using UnityEngine;
using System.Collections.Generic;

public class GlyphVisuals : MonoBehaviour
{
    public List<Sprite> m_visuals = new List<Sprite>();

    // Singleton behaviour
    private static GlyphVisuals sm_instance;
    public static GlyphVisuals Instance
    {
        get
        {
            if (sm_instance == null)
                sm_instance = FindObjectOfType<GlyphVisuals>();
            return sm_instance;
        }
    }

    void Start()
	{
        sm_instance = this;       
	}

    void OnDestroy()
    {
        sm_instance = null;
    }

    public Sprite GetVisual(int id)
    {
        Debug.Assert(id >= 0 && id < m_visuals.Count);
        return m_visuals[id];
    }
}
