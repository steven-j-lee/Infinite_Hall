using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostHand : MonoBehaviour
{
    [SerializeField] private Player_Data player;
    [SerializeField] private GameObject ghost_Hand_Left;
    [SerializeField] private GameObject ghost_Hand_Right;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private TextMeshProUGUI sign;
    private Vector3 originalTextAnglesNeg;
    private Vector3 originalTextAnglesPos;

    private Vector3 originalPosNegLeft;
    private Vector3 originalPosPosLeft;
    private Vector3 originalPosNegRight;
    private Vector3 originalPosPosRight;
    public float speed;
    public float transformSpeed;
    public bool isActive;
    public int SpaceCount;
    public float duration, intensity, rad;

    // Start is called before the first frame update
    void Start()
    {
        originalTextAnglesPos = gameObject.transform.eulerAngles;
        originalTextAnglesPos.z -= 13f;
        originalTextAnglesPos = gameObject.transform.eulerAngles;
        originalTextAnglesPos.z += 13f;

        originalPosNegLeft = ghost_Hand_Left.transform.position - new Vector3(22f, 18f, 0f);
        originalPosPosLeft = ghost_Hand_Left.transform.position + new Vector3(10f, 30f, 0f);

        originalPosNegRight = ghost_Hand_Right.transform.position - new Vector3(4f, 10f, 0f);
        originalPosPosRight = ghost_Hand_Right.transform.position + new Vector3(22f, 24f, 0f);
    }
    
    void FixedUpdate()
    {
        player.health -= 1;
        sign.fontSize = Random.Range(25, 28);
        float pingPongTime = Mathf.PingPong(Time.time * speed, 1);
        float pingPongTimePos = Mathf.PingPong(Time.time * transformSpeed, 1);
        RotateBackAndFourth(pingPongTime);
        moveHands(pingPongTime);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpaceCount += 1;
        }
    }

    private void RotateBackAndFourth(float time)
    {
        sign.gameObject.transform.eulerAngles = Vector3.Lerp(originalTextAnglesNeg, originalTextAnglesPos, time);
    }

    private void moveHands(float time)
    {
        ghost_Hand_Left.transform.position = Vector3.Lerp(originalPosNegLeft, originalPosPosLeft, time);
        ghost_Hand_Right.transform.position = Vector3.Lerp(originalPosPosRight, originalPosNegRight, time);
    }
    
}
