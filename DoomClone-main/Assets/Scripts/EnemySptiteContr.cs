using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySptiteContr : MonoBehaviour
{
	public Transform player;
    
	// Update is called once per frame
    void Update()
    {
        transform.forward = player.forward;
    }
}
