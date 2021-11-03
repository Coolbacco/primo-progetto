using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHeightJump : MonoBehaviour
{
    public Transform playerPos;
    public GameObject indicatorPrefab;
    public Material[] material;

    int index;
    bool jump = false;
    Rigidbody2D rbPlayer;
    GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        rbPlayer = playerPos.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 4)
            index = 0;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            indicator = Instantiate(indicatorPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), transform.rotation);
            indicator.GetComponent<SpriteRenderer>().material = material[index];
        }
        if(jump == true)
        {
            
            if (rbPlayer.velocity.y > 0)
            {
                indicator.transform.position = new Vector2(indicator.transform.position.x, playerPos.transform.position.y + 0.5f);
            }
            else if (rbPlayer.velocity.y < 0)
            {
                jump = false;
                index++;
            }
        }
    }
}
