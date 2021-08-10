using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFlashLight : MonoBehaviour
{
    [SerializeField] private Sprite flashLight;
    [SerializeField] private Sprite samosaHand;

    [SerializeField] private GameObject pointLight;

    private bool isOn;
    
    // Start is called before the first frame update
    void Start()
    {
        pointLight.SetActive(false);
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isOn)
        {
            pointLight.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = samosaHand;
            isOn = false;
        }
        else if(Input.GetKeyDown(KeyCode.F) && !isOn)
        {
            pointLight.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = flashLight;
            isOn = true;
        }
    }
}
