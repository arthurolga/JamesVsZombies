using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFCController : MonoBehaviour
{
    public static AudioClip attackSound, hitSound,zombieDeath,zombieGrowl,zombieBite,playerDeath;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        attackSound = Resources.Load<AudioClip>("Balloon Pop 1");
        hitSound = Resources.Load<AudioClip>("Boss hit 1");
        zombieDeath = Resources.Load<AudioClip>("ZombiePain");
        zombieGrowl = Resources.Load<AudioClip>("Growling");
        zombieBite =  Resources.Load<AudioClip>("ZombieBite");
        
        playerDeath =  Resources.Load<AudioClip>("PlayerDeath");
        audioSrc = GetComponent<AudioSource> ();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public static void PlaySound(string clip){
        switch (clip){
            case "attack":
                audioSrc.PlayOneShot(attackSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "zombieDeath":
                audioSrc.PlayOneShot(zombieDeath);
                break;
            case "zombieGrowl":
                audioSrc.PlayOneShot(zombieGrowl);
                break;
            case "zombieBite":
                audioSrc.PlayOneShot(zombieBite);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath);
                break;
            }
    }
}