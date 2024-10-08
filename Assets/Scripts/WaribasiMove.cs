using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaribasiMove : MonoBehaviour
{
    public float speed = 5f;

    public SushiChat selectedSushi;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(selectedSushi);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        transform.SetAsLastSibling();
    }
}
