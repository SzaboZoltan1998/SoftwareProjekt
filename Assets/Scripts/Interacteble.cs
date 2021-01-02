using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject highLight;
    private void OnEnable()
    {
        highLight = transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            highLight.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            highLight.SetActive(false);
        }
    }
    private void Update()
    {
        if (!highLight.activeInHierarchy)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print(transform.gameObject.name);
            }
        }
    }
 
  
}
