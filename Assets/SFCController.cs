using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFCController : MonoBehaviour
{
    public static AudioClip attackSound, hitSound;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        attackSound = Resources.Load<AudioClip>("Balloon Pop 1");
        hitSound = Resources.Load<AudioClip>("Boss hit 1");
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
            }
    }
}