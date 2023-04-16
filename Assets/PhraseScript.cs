using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhraseScript : MonoBehaviour
{
    public GameObject player;
    public float distanceToShow;
    public SpriteRenderer objectToHideRenderer;
    public float alphaWhenHidden;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer >= distanceToShow)
        {
            Color newColor = objectToHideRenderer.color;
            newColor.a = alphaWhenHidden;
            objectToHideRenderer.color = newColor;
        }
        else
        {
            Color newColor = objectToHideRenderer.color;
            newColor.a = 1f;
            objectToHideRenderer.color = newColor;
        }
    }
}