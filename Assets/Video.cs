using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{

    public VideoPlayer clippy;

    // Start is called before the first frame update
    void Start()
    {
        clippy.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
