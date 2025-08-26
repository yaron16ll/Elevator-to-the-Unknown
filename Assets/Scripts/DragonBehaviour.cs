using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour
{
    Animator animator;
    public GameObject player,sword,dragonSound;//connect to player in Unity
    AudioSource a;
    bool isKilled;
    void Start()
    {
        animator = GetComponent<Animator>();//connect to property in unity
        a = GetComponent<AudioSource>();
     }

    // Update is called once per frame
    void Update()
    {
         float distance = Vector3.Distance(transform.position, player.transform.position);
          isKilled = sword.GetComponent<SwordFighting>().isDragonKilled;
   
            if (distance < 55 &&!isKilled)
        {  
            dragonSound.GetComponent<SphereCollider>().enabled = false;
            //rotate the NPC towards player
            Vector3 target_dir = player.transform.position - transform.position;
            target_dir.y = 0;//stay in x-z plane
            Vector3 temp_dir = Vector3.RotateTowards(transform.forward, target_dir, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(temp_dir);
             animator.SetInteger("State", 1);//talking
         
        }
        else
        {
            animator.SetInteger("State", 0);
            dragonSound.GetComponent<SphereCollider>().enabled = true;
         }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isKilled )
            {
                    a.Play();
                 
                }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            a.Stop();
        }
    }
}

 









