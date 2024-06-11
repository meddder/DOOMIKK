using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileContr : MonoBehaviour
{
	
	float speed = 1f;
	bool UPpress = false;
	bool DOWNpress = false;
	bool RIGHTpress = false;
	bool LEFTpress = false;
	
	public void OnClickUp()
	{
		UPpress = true;
	}
	
	public void OnClickDown()
	{
		DOWNpress = true;
	}
	
	public void OnClickRight()
	{
		RIGHTpress = true;
	}
	
	public void OnClickLeft()
	{
		LEFTpress = true;
	}
	
	public void OffClickUp()
	{
		UPpress = false;
	}
	
	public void OffClickDown()
	{
		DOWNpress = false;
	}
	
	public void OffClickRight()
	{
		RIGHTpress = false;
	}
	
	public void OffClickLeft()
	{
		LEFTpress = false;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (UPpress)//нажали вперёд
		{
			transform.Translate(Vector3.forward * speed * 0.1f);
		}
		
		if (DOWNpress)//нажали назад
		{
			transform.Translate(-Vector3.forward * speed * 0.1f);
		}
		
		if (RIGHTpress)//нажали вправо
		{
			transform.Translate(Vector3.right * speed * 0.1f);
		}
		
		if (LEFTpress)//нажали влево
		{
			transform.Translate(-Vector3.right * speed * 0.1f);
		}
		
    }
}
