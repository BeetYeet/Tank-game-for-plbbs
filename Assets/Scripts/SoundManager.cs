using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource eFXsound;
    public AudioSource firstPlayerSource;
    public AudioSource secondPlayerSource;
    public AudioSource musicSource;
    public float lowPitch;
    public float highPitch;
    public static SoundManager instance = null;

	public AudioClip music;

    //How to use
    // för att använda soundmanager så skriver man i sitt egna skript ljudet man vill ha och sen skriver man:
    // SoundManager.instance.RandomizeSfx("Ljud du använder","Ljud du använder2");
    //Du kan bara skriva in ett ljud om du vill och du kan ta bort .RandomizeSfx om du vill, Rekomenderas dock inte 
    // byt ut randomize sfx till antingen SecondPlayerSource eller firstPlayerSource beroende på vem som ska göra ljudet.

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this){
            Destroy(gameObject);
			return;
		}

        DontDestroyOnLoad(gameObject);
		musicSource.clip = music;
		musicSource.Play();
    }

    public void PlaySingle(AudioClip clip)
    {
        eFXsound.clip = clip;
        eFXsound.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitch, highPitch);
        eFXsound.pitch = randomPitch;
        eFXsound.clip = clips[randomIndex];
        eFXsound.Play();
    }
    public void FirstPlayerSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitch, highPitch);
        firstPlayerSource.pitch = randomPitch;
        firstPlayerSource.clip = clips[randomIndex];
        firstPlayerSource.Play();
    }
    public void SecondPlayerSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitch, highPitch);
        secondPlayerSource.pitch = randomPitch;
        secondPlayerSource.clip = clips[randomIndex];
        secondPlayerSource.Play();
    }
}