using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIViewerBullet : MonoBehaviour
{
    void Start()
    {
        m_viewerImageComponent = this.gameObject.GetComponent<Image>();
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh(){
        Cannon playerCannonComponent = m_playerObjectInstance.GetComponent<Cannon>();
        Cannon.E_BulletAttribute playerCannonBulletAttribute = playerCannonComponent.GetBulletAttribute();
        switch(playerCannonBulletAttribute){
            case Cannon.E_BulletAttribute.eFileBullet:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/FireBullet");
                break;
            case Cannon.E_BulletAttribute.eWaterBullet:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/WaterBullet");
                break;
            case Cannon.E_BulletAttribute.eGreenBullet:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/Green");
                break;
        }
    }

    public GameObject m_playerObjectInstance;
    Image m_viewerImageComponent;
}
