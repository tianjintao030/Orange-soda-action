using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	//Ŀ�ĵأ�������ƽ��Ľ���
	private Vector2 hitPoint;
	//�Զ������ٶ�
	public float speed = 3;
	//�Ƿ���
	private bool clicked = false;

	//���嶯��
	Animator anim;

	void Start()
	{
		//��ȡ�������
		anim = GetComponent<Animator>();
	}
	void Update()
	{
		playerWalk();
	}

	public void playerWalk()
    {

		//��������
		Vector2 curposition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Vector2 moveDirection = hitPoint - curposition;
		//����������
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D raycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			//���������λ�øı��ɫת��
			if(Input.mousePosition.x>=this.transform.position.x)
            {
				
            }
			else if(Input.mousePosition.x < this.transform.position.x)
            {
				
            }
			//�ƶ�
			if (raycast.collider != null)
			{
				hitPoint = new Vector2(raycast.point.x, raycast.point.y);
				anim.SetBool("iswalk", true);
				Debug.Log(raycast.point.x + "/" + raycast.point.y);
				//Debug.Log("clicked object name is ---->" + raycast.collider.gameObject);
			}
			clicked = true;	
		}
		//����˲Ż��Զ�����
		if (clicked) gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, hitPoint, Time.deltaTime * speed);
		//��������ֹͣ����Զ�������ȡ�����
		if (gameObject.transform.position.x == hitPoint.x && gameObject.transform.position.y == hitPoint.y)
		{
			anim.SetBool("iswalk", false);
			clicked = false;
		}
		//������Զ�ǰ��Ŀ�ĵ�ʱ�������˷��������������Զ�������ȡ�����
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			clicked = false;
		}
	}
}

