using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	//目的地，射线与平面的交点
	private Vector2 hitPoint;
	//自动导航速度
	public float speed = 3;
	//是否点击
	private bool clicked = false;

	//定义动画
	Animator anim;

	void Start()
	{
		//获取动画组件
		anim = GetComponent<Animator>();
	}
	void Update()
	{
		playerWalk();
	}

	public void playerWalk()
    {

		//方向向量
		Vector2 curposition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Vector2 moveDirection = hitPoint - curposition;
		//按下鼠标左键
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D raycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			//根据鼠标点击位置改变角色转向
			if(Input.mousePosition.x>=this.transform.position.x)
            {
				
            }
			else if(Input.mousePosition.x < this.transform.position.x)
            {
				
            }
			//移动
			if (raycast.collider != null)
			{
				hitPoint = new Vector2(raycast.point.x, raycast.point.y);
				anim.SetBool("iswalk", true);
				Debug.Log(raycast.point.x + "/" + raycast.point.y);
				//Debug.Log("clicked object name is ---->" + raycast.collider.gameObject);
			}
			clicked = true;	
		}
		//标记了才会自动导航
		if (clicked) gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, hitPoint, Time.deltaTime * speed);
		//如果到达、则停止这次自动导航，取消标记
		if (gameObject.transform.position.x == hitPoint.x && gameObject.transform.position.y == hitPoint.y)
		{
			anim.SetBool("iswalk", false);
			clicked = false;
		}
		//如果在自动前往目的地时，按下了方向键，撤销这次自动导航，取消标记
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			clicked = false;
		}
	}
}

