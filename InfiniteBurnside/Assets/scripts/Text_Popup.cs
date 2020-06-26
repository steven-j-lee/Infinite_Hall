using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_Popup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI key;
    //[SerializeField] private GameObject knockDisable;
    [SerializeField] private GameObject disableGravity;
    [SerializeField] private GameObject chair;

    private AudioSource sound;
    private Rigidbody painting;

    // Start is called before the first frame update
    void Start()
    {
       //sound = knockDisable.GetComponent<AudioSource>();
        painting = disableGravity.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            key.SetText("Look Behind you");
            StartCoroutine(Delay());
            
        }
    }

    private IEnumerator Delay()
    {
        chair.transform.Rotate(90f, 0f, 0f);
        yield return new WaitForSeconds(2f);
        Destroy(key);
        Destroy(disableGravity);
        Destroy(painting);
    }
}
