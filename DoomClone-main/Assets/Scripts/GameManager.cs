using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	int i = 0;
    float fps;
	
	public Text FPS;
    public GameObject shot;
	public GameObject cam;
	
	private bool isShot;
	private byte t2;//shoot
	
    // Start is called before the first frame update
    void Start()
    {
        isShot = false;
		t2=0;
		cam.transform.eulerAngles = new Vector3(0, 0, 0);
    }

	void ShotHole()
	{
		RaycastHit hit;
		var centerPoint = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight /2, 0);//отмеряем центр экрана
        Ray ray = Camera.main.ScreenPointToRay(centerPoint);//бросаем луч из центра камеры
		
		
		
		if(Physics.Raycast (ray, out hit))
		{
			Vector3 relativePos = Camera.main.transform.position - hit.point;
			Vector3 pos = hit.point+hit.normal*0.001f;
			
			Debug.Log (hit.transform.gameObject.tag);
			
			if (hit.transform.gameObject.tag!="enemy")
				Instantiate(shot, pos, Quaternion.FromToRotation(Vector3.forward, hit.normal));
			
			if (hit.transform.gameObject.tag=="enemy")	
			{
				Enemy_Contr ec = hit.collider.gameObject.GetComponent<Enemy_Contr>();
				ec.HP -=20;
			}
			
		}
	}
	
	void Update() 
	{
        fps = (float)Mathf.Round(1/Time.deltaTime);
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
		if(t2>=50)
		{
			isShot = false;
			t2=0;
		}
		
		if(isShot)
		{
		   t2++;
		}
		
        if((Input.GetAxis("Fire1")==1f)&&!isShot)
		{
			ShotHole();
			isShot = true;
			t2 = 0;
		}
		
		i ++;
		if (i>=25)
		{
			FPS.text = fps + " FPS";
			i=0;
		}
    }
}
