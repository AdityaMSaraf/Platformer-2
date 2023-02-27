using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{

    public TextMeshProUGUI scoreCount;
    int scoreNum;
    public GameObject player;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, Vector3.up, out hit, 1.3f, layerMask))
        {
            if (hit.collider.gameObject.name == "Question(Clone)")
            {
                scoreNum += 100;
            }
            else if (hit.collider.gameObject.name == "Brick(Clone)")
            {
                hit.collider.gameObject.SetActive(false);
                scoreNum+= 100;
            }
        }
        scoreCount.text = $"Mario\n{scoreNum}";    
    }
}
