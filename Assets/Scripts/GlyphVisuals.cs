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
            Debug.Assert(sm_instance != null);
            return sm_instance;
        }
    }

    void Start()
	{
        Debug.Assert(sm_instance == null, "There can be only one GlyphVisuals per scene");
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
