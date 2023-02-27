using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rayLength;
    public LayerMask layerMask;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI score;
    private int scoreCount = 0;
    private int coinCount = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                if (hit.collider.name.Equals("Brick(Clone)"))
                {
                    Destroy(hit.transform.gameObject);
                    scoreCount += 30;
                    score.text = scoreCount.ToString();
                }
                if (hit.collider.name.Equals("Question(Clone)"))
                {
                    String c = coins.ToString();
                    coinCount++;
                    coins.text = coinCount.ToString();
                    
                }
                // Destroy(hit.transform.gameObject);
            }
        }
        
        
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime,0,0);
        }
    }
}
