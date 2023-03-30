using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    void Start(){
        m_base = this.transform.Find("Base").GetComponent<Image>();
        m_gauge = this.transform.Find("Gauge").GetComponent<Image>();
    }

    void Update(){
        if(m_owner == null){
            Destroy(this.gameObject);
        }else{
            RectTransform rectTrans = this.transform as RectTransform;
            rectTrans.position = RectTransformUtility.WorldToScreenPoint(Camera.main, m_owner.transform.position);
            rectTrans.position = new Vector3(rectTrans.position.x, rectTrans.position.y + m_gaugeYOffset, rectTrans.position.z);
        }
    }

    public void Refresh(float gaugeRate){
        m_gauge.fillAmount = gaugeRate;
    }

    public void SetGaugeOwner(GameObject owner){
        m_owner = owner;
        this.transform.SetParent(GameObject.Find("HPGaugeParent").transform);
    }

    public static HPGauge CreateHPGauge(GameObject owner){
        GameObject hpGaugePrefab = Resources.Load<GameObject>("Prefabs/HPGauge");
        GameObject hpGaugeInstance = Instantiate(hpGaugePrefab);
        HPGauge hpgauge = hpGaugeInstance.GetComponent<HPGauge>();
        hpgauge.SetGaugeOwner(owner);
        return hpgauge;
    }

    Image m_base;
    Image m_gauge;
    [SerializeField]
    GameObject m_owner;
    [SerializeField]
    float m_gaugeYOffset;
}
