using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    public AudioClip bgm;
    public AudioClip block;
    public AudioClip fall;
    public AudioClip gameover;
    public AudioClip hunda;
    public AudioClip zommbi;

    private AudioSource audioSource;

    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void JukeBoxOn(string str){
        audioSource.volume = 1.0f;
        audioSource.pitch = 0.65f;
        switch (str)
        {
            case "bgm" :audioSource.clip = bgm;break;
            case "block" :audioSource.clip = block;break;
            case "fall" :audioSource.clip = fall;break;
            case "gameover" :
            audioSource.clip = gameover;
            audioSource.volume = 0.5f;
            audioSource.pitch = 0.65f;
            break;
            case "hunda" :audioSource.clip = hunda;break;
            case "zommbi" :audioSource.clip = zommbi;break;
            default:break;
        }
        audioSource.Play();
        
    }
}
