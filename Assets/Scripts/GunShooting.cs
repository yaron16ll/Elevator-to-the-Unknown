using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShooting : MonoBehaviour
{
    public GameObject target;
    public GameObject aCamera;
    private AudioSource sound;
    private LineRenderer lineofFire;
    public GameObject startFire;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        lineofFire = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                StartCoroutine(Fire());
                if(hit.collider.gameObject == enemy.gameObject)
                {
                  Animator enemyAnimator = enemy.GetComponent<Animator>();
                //    enemyAnimator.SetInteger("State",2);
                   //UnityEngine.AI.NavMeshAgent agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
                    //agent.enabled = false;
                }
            }
        }
    }
    IEnumerator Fire()
    {
        sound.Play();
        // draw line of fire
        lineofFire.enabled = true;
        lineofFire.SetPosition(0, startFire.transform.position);
        lineofFire.SetPosition(1, target.transform.position);
        yield return new WaitForSeconds(0.02f);
        lineofFire.enabled = false;

    }
}
