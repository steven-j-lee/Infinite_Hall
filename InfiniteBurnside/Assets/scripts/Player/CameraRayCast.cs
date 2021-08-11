using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    [SerializeField] private int rayCastLenght;
    [SerializeField] private LayerMask interactableLayer;
    private GameObject raycastedObj;

    [SerializeField] private GameObject[] roses;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit collision;
        Vector3 line = transform.TransformDirection(Vector3.forward);
        
        Debug.DrawRay(line, Vector3.forward, Color.red);

        if (Physics.Raycast(transform.position,
            line,
            out collision,
            rayCastLenght,
            interactableLayer.value))
        {
            if (collision.collider.CompareTag("ghost"))
            {
                GameObject.FindWithTag("ghost").GetComponent<DropDemon>().isSeen = true;
            }

            if (collision.collider.CompareTag("pink") && Input.GetMouseButtonDown(0))
            {
                Debug.Log("pink");
                roses[0].GetComponent<InitRose>().taken = true;
                roses[0].GetComponent<MeshRenderer>().enabled = false;
            }
            
            if (collision.collider.CompareTag("white") && Input.GetMouseButtonDown(0))
            {
                Debug.Log("white");
                roses[1].GetComponent<InitRose>().taken = true;
                roses[1].GetComponent<MeshRenderer>().enabled = false;
            }
            
            if (collision.collider.CompareTag("flamen") && Input.GetMouseButtonDown(0))
            {
                Debug.Log("flamen");
                roses[2].GetComponent<InitRose>().taken = true;
                roses[2].GetComponent<MeshRenderer>().enabled = false;
            }
            
            if (collision.collider.CompareTag("blue") && Input.GetMouseButtonDown(0))
            {
                Debug.Log("blue");
                roses[3].GetComponent<InitRose>().taken = true;
                roses[3].GetComponent<MeshRenderer>().enabled = false;
            }

            if (collision.collider.CompareTag("answer") && Input.GetMouseButtonDown(0))
            {
                GameObject.FindWithTag("answer").GetComponent<EnableLastSceneLobby>().isStolen = true;
            }
        }
    }
}
