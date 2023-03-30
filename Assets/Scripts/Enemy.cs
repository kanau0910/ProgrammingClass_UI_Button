using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_hpNow = m_hpMax;

        m_hpgauge = HPGauge.CreateHPGauge(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        m_hpNow += damage;

        if(m_hpNow >= m_hpMax){
            m_hpNow = m_hpMax;
        }
        if(m_hpNow <= m_hpMin){
            m_hpNow = m_hpMin;
            Destroy(this.gameObject);
        }

        float hpRate = (float)m_hpNow / m_hpMax;
        m_hpgauge.Refresh(hpRate);
    }

    [SerializeField]
    int m_hpMax;
    [SerializeField]
    int m_hpMin;
    [SerializeField]
    int m_hpNow;

    HPGauge m_hpgauge;
}
