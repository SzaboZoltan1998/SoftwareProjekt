using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Coordinator; // Singleton pattern unity modra

    GameObject interactable = null;
    bool taskOpened = false;
    public Button use;
    public GameObject taskWindow;

    // Start is called before the first frame update
    void Start()
    {
        use.gameObject.SetActive(false);
        taskWindow.SetActive(false);
    }

    void Awake()
    {
        if (Coordinator == null)
        {
            Coordinator = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable != null)
        {
            if (taskOpened)
            {
                if (Input.GetAxisRaw("Cancel") != 0) Close();
            }
            else
            {
                if (Input.GetAxisRaw("Submit") != 0) Use();
            }        
        }   
    }

    public void setInteractable(GameObject obj)
    {
        interactable = obj;
        use.gameObject.SetActive(true);
    }

    public void Use()
    {
        //print(interactable.name);
        taskOpened = true;
        taskWindow.transform.GetChild(0).GetComponent<Text>().text = interactable.name;
        taskWindow.SetActive(true);
    }

    public void Close()
    {
        taskWindow.SetActive(false);
        taskOpened = false;
    }

    public void unsetInteractable()
    {
        if (taskOpened) Close();
        use.gameObject.SetActive(false);
        interactable = null;
    }

}
