using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);
        
        if (GameObject.FindGameObjectsWithTag("menuMusic").Length == 1) 
        {
            changeVolume();
            PlayMusic();
        }
        else
        {
            DestroyObject(transform.gameObject);
        }

    }

    public void changeVolume() // uppdates music volume
    {
        audioSource = GetComponent<AudioSource>();
        float menuVolume = PlayerPrefs.GetFloat("menuMusic");
        audioSource.volume = menuVolume;
    }

    public void PlayMusic() // starts music 
    {

        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic() // stop/remove music object
    {
        DestroyObject(transform.gameObject);
    }
}
