using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_attack : StateMachineBehaviour
{
    public float speed = 2.5f;
	public float attackRange = 3f;
	public float visionRange =  8f;

	Transform player;
	Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       	player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   		// Vector2 target = new Vector2(player.position.x, rb.position.y);
		// if(Vector2.Distance(player.position, rb.position) <= visionRange)
		// {
		// 	Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		// 	rb.MovePosition(newPos);
		// }
       	if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("Attack");
		}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
