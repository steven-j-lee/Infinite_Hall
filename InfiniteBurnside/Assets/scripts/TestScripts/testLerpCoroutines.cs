using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLerpCoroutines : MonoBehaviour
{
    [SerializeField] private GameObject targetLocation;
    public float speed;
    public float seconds;
    private Vector3 startPos;
    [SerializeReference] private bool isDone;
    
    private void Awake()
    {
        isDone = false;
        startPos = gameObject.transform.position;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cutscene(10f));
    }
    
    private IEnumerator Cutscene(float seconds)
    {
        yield return EnableWormChase();
        yield return new WaitForSeconds(seconds);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator EnableWormChase()
    {
        float t = 0f;
        while (t < speed)
        {
            gameObject.transform.position = Vector3.Lerp(startPos, targetLocation.transform.position,
                t/speed);
            t += Time.deltaTime;
            yield return null;
        }
        isDone = true;
        yield return null;
    }
    
}
