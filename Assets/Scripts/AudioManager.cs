using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;
    [SerializeField]  public AudioSource easy;
    [SerializeField] public AudioSource medium;
    [SerializeField]  public AudioSource hard;
   
    [Header("------- Audio Clip --------")]
    public AudioClip easyClip;
    public AudioClip mediumClip;
    public AudioClip hardClip;
    public AudioClip BoxDestroyed;
    public AudioClip Music;
    public AudioClip background;
   

    private bool isPaused = false;
    


    // Start is called before the first frame update

    private void Awake()
    {   
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void musicPlayer(){
        int diff = PlayerPrefs.GetInt("Difficulty");
        float musicVolume = PlayerPrefs.GetFloat("gameMusic");
        if (diff == 1){
            easy.PlayDelayed(5.77f); // swich 5 to beat for the difficulity in spawner to match cubes
            Debug.Log(musicVolume);
            easy.volume=musicVolume;
        }
        if(diff == 2){
            medium.PlayDelayed(5);  // swich 5 to beat for the difficulity in spawner to match cubes
            medium.volume = musicVolume;
        }
        if(diff == 3){
            hard.PlayDelayed(0.75f);    // swich to beat for the difficulity in spawner to match cubes
            hard.volume = musicVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.isGamePaused == true && isPaused == false){
            int diff = PlayerPrefs.GetInt("Difficulty");
            if(diff == 1){easy.Pause();}
            if(diff == 2){medium.Pause();}
            if(diff == 3){hard.Pause();}
            isPaused = true;
            Debug.Log("paused");
        }
        if(PauseMenu.isGamePaused == false && isPaused == true){
            int diff = PlayerPrefs.GetInt("Difficulty");
            if(diff == 1){easy.UnPause();}
            if(diff == 2){medium.UnPause();}
            if(diff == 3){hard.UnPause();}
            isPaused = false;
        }
    }
    void Start(){
        musicPlayer();
    }

    public void playEasyMusic(AudioSource music){
        easy.Play(0);
    }
    public void playMediumMusic(AudioSource music){
        medium.Play(0);
    }
    public void playHardMusic(AudioSource music){
        hard.Play(0);
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
