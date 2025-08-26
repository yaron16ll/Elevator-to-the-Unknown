using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    Animator animator;
    public GameObject player,king;//connect to player in Unity
     public RawImage text;
    bool isKingFound = false;

     // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//connect to property in unity
           

    }

    // Update is called once per frame
    void Update()
    {
         isKingFound = king.GetComponent<KingFound>().isFound;

    float distance = Vector3.Distance(transform.position, player.transform.position);

        if (!isKingFound ) {
        if (distance < 9.2)
        {
             text.gameObject.SetActive(true);    
            animator.SetInteger("State", 1);//talking
        }
        else
        {          
           text.gameObject .SetActive(false);   
            animator.SetInteger("State", 0);

         }
        }
    }
}
