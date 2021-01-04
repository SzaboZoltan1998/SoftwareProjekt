using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{
    public bool isFinished ;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Game.Coordinator.setInteractable(this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Game.Coordinator.unsetInteractable();
        }
    }
    private void Update()
    {
        
    }
 
  
}
