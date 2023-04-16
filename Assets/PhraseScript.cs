using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhraseScript : MonoBehaviour
{
    public GameObject player;
    public float distanceToShow;
    public SpriteRenderer objectToHideRenderer;
    public float alphaWhenHidden;
    public Sprite iconSprite;
    public Sprite phraseSprite;

    private bool flagDistanceToPlayerAboveThreshold;
    private float distanceToPlayer;

    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = iconSprite;

        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        flagDistanceToPlayerAboveThreshold = distanceToPlayer >= distanceToShow;
        ChangeOpacity(alphaWhenHidden);
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Runs ChangeOpacity(x) if distance went above or beyond threshold
        // uses flagDistanceToPlayerAboveThreshold to understand previous state and update only if changed
        if (distanceToPlayer >= distanceToShow && !flagDistanceToPlayerAboveThreshold)
        {
            flagDistanceToPlayerAboveThreshold = true;
            ChangeOpacity(alphaWhenHidden);
        }
        else if (distanceToPlayer < distanceToShow && flagDistanceToPlayerAboveThreshold)
        {
            flagDistanceToPlayerAboveThreshold = false;
            ChangeOpacity(1f);
        }
    }


    /// <summary>Changes alpha chanel of <c>objectToHideRenderer</c></summary>
    /// <param name="newOpacity">New opacity value</param>
    private void ChangeOpacity(float newOpacity)
    {
        Color newColor = objectToHideRenderer.color;
        newColor.a = newOpacity;
        objectToHideRenderer.color = newColor;
    }
}