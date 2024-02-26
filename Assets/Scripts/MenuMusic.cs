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
            audioSource = GetComponent<AudioSource>();
            PlayMusic();
        }
        else
        {
            DestroyObject(transform.gameObject);
        }

    }

    public void PlayMusic()
    {

        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        Debug.Log("stop");
        DestroyObject(transform.gameObject);
    }
}
