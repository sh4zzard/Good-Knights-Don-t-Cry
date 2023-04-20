using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoContainerScript : MonoBehaviour
{
    public PlayableDirector pd;
    private RawImage ri;

    private float length = 6.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        ri = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > length)
        {
            ri.enabled = false;
            pd.Play();
        }
    }
}
