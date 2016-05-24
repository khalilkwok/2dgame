using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    [HideInInspector]
    public bool FacingRight = true;
    [HideInInspector]
    public bool Jump = false;

    public float MoveForce = 365f;
    public float MaxSpeed = 5f;

    private Animator Anim;
	
    void Awake()
    {
        Anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");//获取水平输入(按→>0 按←<0)
        //设置角色行进功能

        if (h* GetComponent<Rigidbody2D>().velocity.x < MaxSpeed)
        {//给玩家一个在x轴上的力
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * MoveForce);//h取值为[-1,1]，控制了方向
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > MaxSpeed) //Mathf.Abs取绝对值函数
        {//将玩家在Ｘ轴的速度设为MaxSpeed
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);//Mathf.Sign　速度为正返回１，为负返回－１
        }
        //设置转身功能
        if (h > 0 && !FacingRight)
        {
            Flip();
        }
        else if (h < 0 && FacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
