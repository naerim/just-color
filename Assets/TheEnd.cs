using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheEnd : MonoBehaviour
{
    public static bool over;

    // Start is called before the first frame update
    void Start()
    {
        over = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PurpleBall")
        {
            over = true;
        }
        else if(coll.gameObject.tag == "BlueBall")
        {
            over = true;
        }
        else if(coll.gameObject.tag == "YellowBall")
        {
            over = true;
        }
        else if (coll.gameObject.tag == "OrangeBall")
        {
            over = true;
        }
    }
}