using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextToScreen : MonoBehaviour
{
    [SerializeField] private ShipMovement ship;

    void FixedUpdate()
    {
        gameObject.GetComponent<TextMeshPro>().text = ship.score.ToString();

        if (gameObject.tag.Equals("life_mini"))
        {
            gameObject.GetComponent<TextMeshPro>().text = ship.lives.ToString();
        }
    }
}
