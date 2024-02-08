using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;



public class itemcollector : MonoBehaviour
{
    private int points = 0;

    [SerializeField] private TextMeshProUGUI Kiwitext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
    

        if (collision.CompareTag("Kiwi"))
        {
            points += 1;
            Destroy(collision.gameObject);
            Kiwitext.text = "Frukter: " + points;
        }


    }



}



        