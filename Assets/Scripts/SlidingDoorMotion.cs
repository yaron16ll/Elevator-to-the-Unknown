using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlidingDoorMotion : MonoBehaviour
{
    AudioSource audio;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("OpenState", true);
        audio.PlayDelayed(0.8f);
    }


    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("OpenState", false);
        audio.PlayDelayed(0.8f);
    }
}
