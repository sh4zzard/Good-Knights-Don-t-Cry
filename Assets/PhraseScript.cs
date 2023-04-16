using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class PhraseScript : MonoBehaviour
{
    public GameObject player;
    public float distanceToShow;
    public SpriteRenderer objectToHideRenderer;
    public float alphaWhenHidden;
    public Sprite iconSprite;
    public Sprite phraseSprite;

    private bool isDistanceToPlayerAboveThreshold;
    private float distanceToPlayer;

    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        if (iconSprite == null || phraseSprite == null)
        {
            Debug.LogWarning("You've not assigned sprites to [" + gameObject + "]");
        }

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = iconSprite;

        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        isDistanceToPlayerAboveThreshold = distanceToPlayer >= distanceToShow;
        ChangeOpacity(alphaWhenHidden);
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Runs ChangeOpacity(x) if distance went above or beyond threshold
        // uses isDistanceToPlayerAboveThreshold to understand previous state and update only if changed
        if (distanceToPlayer >= distanceToShow && !isDistanceToPlayerAboveThreshold)
        {
            isDistanceToPlayerAboveThreshold = true;
            ChangeOpacity(alphaWhenHidden);
        }
        else if (distanceToPlayer < distanceToShow && isDistanceToPlayerAboveThreshold)
        {
            isDistanceToPlayerAboveThreshold = false;
            ChangeOpacity(1f);
            _spriteRenderer.sprite = iconSprite;
        }

        if (!isDistanceToPlayerAboveThreshold && Input.GetKeyDown(KeyCode.R))
        {
            _spriteRenderer.sprite = phraseSprite;
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