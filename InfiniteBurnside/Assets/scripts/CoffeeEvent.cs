using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeEvent : MonoBehaviour
{
    [SerializeField] private GameObject npcNextToCoffee;
    [SerializeField] private GameObject npcNextToCoffeeNext;
    [SerializeField] private GameObject coffeenpc;
    [SerializeField] private GameObject coffeenpcNext;
    [SerializeField] private GameObject coffeeInteract;
    
    
    //box event
    [SerializeField] private GameObject interactableBox;
    [SerializeField] private GameObject boxNPC;
    [SerializeField] private GameObject boxNPCNext;
    
    //kid event
    [SerializeField] private GameObject dad;
    [SerializeField] private GameObject son;
    [SerializeField] private GameObject dadAndSonNpc;
    
    void Update()
    {
        if (coffeeInteract.GetComponent<CoffeeInteract>().signal)
        {
            coffeeInteract.SetActive(false);
            npcNextToCoffee.SetActive(false);
            coffeenpc.SetActive(false);
            coffeenpcNext.SetActive(true);
            npcNextToCoffeeNext.SetActive(true);
        }

        if (interactableBox.GetComponent<CoffeeInteract>().signal)
        {
            boxNPC.SetActive(false);
            boxNPCNext.SetActive(true);
            interactableBox.SetActive(false);
        }

        if (son.GetComponent<CoffeeInteract>().signal)
        {
            dad.SetActive(false);
            son.SetActive(false);
            dadAndSonNpc.SetActive(true);
        }
    }
}
