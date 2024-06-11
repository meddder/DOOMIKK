using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public GameObject cam;
	public float speed = 1f;//объявляем переменную скорости
	public float FieldX;//размер области для движения по оси Х
	public float FieldZ;//размер области для движения по оси У
	public float turnSpeed = 10f; //"чувствительность" камеры
	public float JumpPower=5f;
	public Rigidbody rb;
	
	
	private bool isFly;
	private bool isRun;
	private bool isShot;
	private byte t;//jump
	private byte t2;//shoot
	
	public Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
        isFly = false;
		isShot = false;
		t=0;
		t2=0;
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(t>=10*JumpPower)
		{
			isFly = false;
			t=0;
		}
		
		if(isFly)
		{
		   t++;
		}
		
		if(t2>=50)
		{
			isShot = false;
			t2=0;
			anim.SetBool("isShooting", false);
		}
		
		if(isShot)
		{
		   t2++;
		}
		
		//if(transform.position.x < FieldX)//если позиция объекта меньше чем позиция "стенки" по оси Х(больше нуля)
		
		if(Input.GetKey(KeyCode.D))//если нажата клавиша D
		{
			
			transform.Translate(Vector3.right * speed * 0.1f);//передвигаем объект вправо с заданной скоростью
		}
		
		//if (transform.position.x > -FieldX)//если позиция объекта меньше чем позиция "стенки" по оси Х(меньше нуля)
		
		if(Input.GetKey(KeyCode.A))//если нажата клавиша А
		{
			transform.Translate(-Vector3.right * speed * 0.1f);//передвигаем объект влево с заданной скоростью
		}
		
		
		if(Input.GetKey(KeyCode.LeftShift))
			isRun = true;
		
		//if(transform.position.z < FieldZ)//если позиция объекта меньше чем позиция "стенки" по оси Y(больше нуля)
		
		if(Input.GetKey(KeyCode.W))//если нажата клавиша W
		{
			transform.Translate(Vector3.forward * speed * 0.1f);//передвигаем объект вверх с заданной скоростью
			if(isRun)
				transform.Translate(Vector3.forward * speed * 0.1f);
		}
		
		//if (transform.position.z > -FieldZ)//если позиция объекта меньше чем позиция "стенки" по оси Y(меньше нуля)
		
		if(Input.GetKey(KeyCode.S))//если нажата клавиша S
		{
			transform.Translate(-Vector3.forward * speed * 0.1f);//передвигаем объект вниз с заданной скоростью
				if(isRun)
					transform.Translate(-Vector3.forward * speed * 0.1f);
		}
		
		isRun = false;
		
		//камера
		transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);//движение 3d камеры по горизонтали, а точнее вращение объекта к которому привязана камера
		if( (cam.transform.eulerAngles.x<70 || cam.transform.eulerAngles.x>290 || (cam.transform.eulerAngles.x>70&&Input.GetAxis("Mouse Y")>0&&cam.transform.eulerAngles.x<100) || (cam.transform.eulerAngles.x>110&&Input.GetAxis("Mouse Y")<0&&cam.transform.eulerAngles.x<290)))
		//разобраться с ограничениями
			cam.transform.Rotate(-Input.GetAxis("Mouse Y") * turnSpeed, 0, 0);//движение 3d камеры по вертикали
			
			
		if(Input.GetKey(KeyCode.Space)&& !isFly)
		{
			rb.AddForce(0, JumpPower/* * 0.1f*/, 0, ForceMode.Impulse);
			isFly = true;
			t = 0;
		}
		
		if((Input.GetAxis("Fire1")==1f)&&!isShot)
		{
			anim.SetBool("isShooting", true);
			//ShotHole();
			isShot = true;
			t2 = 0;
		}
    }
}
