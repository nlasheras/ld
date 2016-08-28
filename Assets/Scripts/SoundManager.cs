using UnityEngine;
using System.Collections;

public enum SoundEffect
{
    UnlockPuzzles
}

public class SoundManager : MonoBehaviour 
{
    private static SoundManager s_instance;
    private AudioSource m_audioSource;

    public AudioClip m_unlockPuzzles;

    public static SoundManager Instance
    {
        get
        {
            Debug.Assert(s_instance != null);
            return s_instance;
        }
    }

    void OnEnable()
	{
        Debug.Assert(s_instance == null);
        s_instance = this;

        m_audioSource = GetComponent<AudioSource>();
	}

    void OnDisable()
    {
        s_instance = null;
    }
	
	public void PlaySound(SoundEffect fx)
	{
        m_audioSource.PlayOneShot(ChooseClip(fx));
	}

    private AudioClip ChooseClip(SoundEffect fx)
    {
        switch(fx)
        {
            case SoundEffect.UnlockPuzzles: return m_unlockPuzzles;
        }
        return null;
    }
}
