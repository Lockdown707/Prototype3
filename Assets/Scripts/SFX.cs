using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    //Audio Variables
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip kaboom;
    public AudioClip yeeyee;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Make Boom Sound If I press Space
        if (Input.GetKeyDown(KeyCode.Space) && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(kaboom);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(yeeyee);
        }
        
    }
}
