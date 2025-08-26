using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class DrawerBehaviour : MonoBehaviour
{
    public GameObject PlayerEye;
    public GameObject CrossHair;
    public GameObject CrossHairTouch;
    public Text openText;
    public Text closeText;
    public GameObject chestOfDrawers;
    public GameObject enemy;
    Animator a;
    AudioSource sound;
    private bool isDrawerOpened = false;
    NavMeshAgent enemyAgent;
    bool enemyIsMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        a = chestOfDrawers.GetComponent<Animator>();
        sound = chestOfDrawers.GetComponent<AudioSource>();
        enemyAgent = enemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (enemyIsMoving&& enemyAgent.enabled == true)
        {

            enemyAgent.SetDestination(PlayerEye.transform.position);

        }
        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit))
        {
            if (hit.collider == GetComponent<Collider>()) // if ray hits the collider of drawer
            {
                CrossHair.gameObject.SetActive(false);
                CrossHairTouch.gameObject.SetActive(true);
                if (!isDrawerOpened)
                {
                    openText.gameObject.SetActive(true);
                    closeText.gameObject.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        a.SetBool("OpenState", true);
                        sound.PlayDelayed(0.6f);
                        isDrawerOpened = true;
                        Animator enemyAnimator = enemy.GetComponent<Animator>();
                        enemyAnimator.SetInteger("State",1);
                        enemyAgent.SetDestination(PlayerEye.transform.position);
                        enemyIsMoving = true;
                    }
                }
                else // the drawer is opened
                {
                    openText.gameObject.SetActive(false);
                    closeText.gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        a.SetBool("OpenState", false);
                        sound.PlayDelayed(0.6f);
                        isDrawerOpened = false;

                    }
                }
            }
            else
            {
                CrossHair.gameObject.SetActive(true);
                CrossHairTouch.gameObject.SetActive(false);
                openText.gameObject.SetActive(false);

            }
        }
    }
}
