using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_Popup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI key; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            key.SetText("A strange writings on the painting reads " + "\n" +
                "Only for those who solve the riddle may pass");
        }
        else
        {
            key.SetText(" ");
        }
    }
}
