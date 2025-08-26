using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickGun : MonoBehaviour
{
    public GameObject gunInDrawer;
    public GameObject gunInHand;
    public Text closeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             closeText.gameObject.SetActive(false);
         
    }

    private void OnMouseDown()
    {
         gunInDrawer.SetActive(false);
        gunInHand.SetActive(true);
     }
}
