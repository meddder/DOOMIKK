using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Contr : MonoBehaviour
{
	public int HP;
	public bool isHit;
	

	public Transform player;
	public Transform vision;
	
	public Animator anim;
	
	private bool life;
	private float ang;
	

    void Start()
    {

		isHit = false;
		life = true;
    }
	

    void FixedUpdate()
    {
		Vector3 targetDir = player.position - transform.position;
		
		ang = Vector3.SignedAngle(targetDir, vision.position - transform.position, Vector3.up);
		
		if (ang<0)
			ang = 360f+ang;
		
		if(life)
		{
			if (ang<22.5f || ang>337.5)
				anim.SetInteger("CDdir", 1);
			
			if (ang>22.5f && ang<67.5f)
				anim.SetInteger("CDdir", 2);
			
			if (ang>67.5f && ang<112.5f)
				anim.SetInteger("CDdir", 3);
			
			if (ang>112.5f && ang<157.5f)
				anim.SetInteger("CDdir", 4);
			
			if (ang>157.5f && ang<202.5f)
				anim.SetInteger("CDdir", 5);
			
			if (ang>202.5f && ang<247.5f)
				anim.SetInteger("CDdir", 6);
			
			if (ang>247.5f && ang<292.5f)
				anim.SetInteger("CDdir", 7);
			
			if (ang>292.5f && ang<337.5f)
				anim.SetInteger("CDdir", 8);
		}
		if (HP<=0&&life)
		{
			anim.SetInteger("CDdir", 20);
			Debug.Log("enemy_is_dead");
			life = false;
		}

    }
}
