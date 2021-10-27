using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RammingCreature : SpecialCreature
{
    // Start is called before the first frame update
    private LevelManager _levelManager;
    private bool is_moving = false;
    public int speed = 3;
    public Transform target;
    
    // For clicking
    public GameObject player;

    new void Start()
    {
        base.Start();
        _levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (is_moving)
        {
            _levelManager.freeze_player = true;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                is_moving = false;
                _levelManager.freeze_player = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            Destroy(collision.gameObject);
        }
    }
    
    public override bool Paint(bool paintWithBrush)
    {
        if (SpecialCreatureUtil.ActivateSpecialCreature(
                isPainted,
                IsMouseOver,
                player.transform.position,
                transform.position,
                _levelManager,
                paintColour1,
                paintColour2,
                paintQuantity1,
                paintQuantity2,
                Material,
                Color.magenta))
        {
            originalColour = Material.color;
            isPainted = true;
            is_moving = true;
            return true;
        }
        return false;
    }
}