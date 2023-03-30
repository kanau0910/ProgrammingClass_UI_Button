using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    // Update is called once per frame
    public override void Update()
    {
        // ターゲットへの進行方向.
        Vector3 targetDirection = m_targetObject.transform.position - this.transform.position;
        targetDirection = targetDirection.normalized;

        // 進行方向ベクトルに、ターゲットへの進行方向の成分を混ぜる.
        m_moveDirection = m_moveDirection + targetDirection * 0.1f;
        m_moveDirection = m_moveDirection.normalized;

        m_moveDistance = m_moveDirection * m_speed * Time.deltaTime;

        this.transform.position += m_moveDistance;
    }
}
