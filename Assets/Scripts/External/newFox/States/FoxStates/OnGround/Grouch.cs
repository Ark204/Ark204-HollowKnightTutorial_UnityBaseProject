using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grouch : OnGround
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //取消上方碰撞器
        m_stateController.GetComponent<PolygonCollider2D>().enabled = false;
        //播放趴下动画
        m_animator.Play("crouch");
    }
    //重写update方法
    public override void update()
    {
        MoveMent();
        //调用自己的Shut方法
        Shut();
        //GroundJump();//不再处理跳跃
        Grouch();
        GroundFall();
        //如果不再按下下蹲键且上面没有障碍物或者正在下落
        if (m_rigidbody2D.velocity.y<-0.1||(!m_fox.grouchPressed && !Physics2D.OverlapCircle(m_fox.CellingCheck.position, 0.2f,m_fox.layerMask)))
        {
            //切回站立状态
            m_stateController.ChangeState(FoxState.idle);
        } 
    }
    public override void exit()
    {
        m_stateController.GetComponent<PolygonCollider2D>().enabled = true;
    }
    //重写Shut方法
    protected override void Shut()
    {
        //如果按下射击
        if (m_fox.shutPressed)
        {
            GameObject bullet = m_stateController.LoadPrefabs("Prefabs/bullet");
            //降低射击高度
            bullet.transform.position = new Vector2(m_transform.position.x + m_fox.shutStartdistance * m_transform.localScale.x, m_transform.position.y+m_fox.crouchdistance);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = new Vector2(10 * m_transform.localScale.x, bulletRb.velocity.y);
            m_fox.shutPressed = false;
        }
    }
}
