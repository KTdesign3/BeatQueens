using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SoundClip
{
    // Use this class to define sound clips and assign them an id which they will be called by.
    public AudioClip clip;
    public string id;
}

public class SoundManager : MonoBehaviour
{
    // Instance
    public static SoundManager inst;

    //Volume
    public float musicVolume;
    public float sfxVolume;

    // Instantiate Audio Sources
    // note: we are creating them by code so that we can access each one by its name
    public AudioSource musicSource; // audio source for music
    public static AudioSource sfxSource; // audio source for sfx

    
    // The list to store our sound clips in. Create an object for the SoundManager and define the clips on it.
    public SoundClip[] soundClips;



    // Start
    void Start()
    {
        if (inst == null) inst = this;

        // Add AudioSource components to the Game Object
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.volume = musicVolume;
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.volume = sfxVolume;

        // Set loop property of musicSource
        musicSource.loop = true; // Loops music
    }


    // Update is called once per frame
    void Update()
    {
        // Hotkey to turn music on and off (comment out if you don't want this)
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }
            else
            {
                musicSource.Play();
            }

        }
    }

    // Play Music Function
    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    // Play SFX Function
    public void PlaySound(string id) // if you want to use the audio source created by this script just use 'SoundManager.inst.sfxSource' when calling the sound effect
    {
        AudioClip clip;
        foreach (SoundClip sound in soundClips)
        {
            if (sound.id == id)
            {
                clip = sound.clip;
                sfxSource.volume = sfxVolume;
                sfxSource.PlayOneShot(clip, sfxVolume); //PlayOneShot allows multiple sounds to be overlayed/played at once
            }
        }
        return;
    }

    // Play SFX Function with Custom Audio Source
    public void PlaySound(string id, AudioSource audio) // if you want to use the audio source created by this script just use 'SoundManager.inst.sfxSource' when calling the sound effect
    {
        AudioClip clip;
        foreach (SoundClip sound in soundClips)
        {
            if (sound.id == id)
            {
                clip = sound.clip;
                audio.PlayOneShot(clip, sfxVolume); //PlayOneShot allows multiple sounds to be overlayed/played at once
            }
        }
        return;
    }

}
