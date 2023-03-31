using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunction : MonoBehaviour
{
    public void OnClickShootButton(){
        Cannon playerCannonComponent = m_playerObjectInstance.GetComponent<Cannon>();
        playerCannonComponent.OnClickShootUIButton();
    }

    public void OnClickWeaponViewer(){
        Cannon playerCannonComponent = m_playerObjectInstance.GetComponent<Cannon>();
        playerCannonComponent.ChangeWeaponType();
        UIViewerWeapon uiViewerWeapon = m_uiViewerWeaponInstance.GetComponent<UIViewerWeapon>();
        uiViewerWeapon.Refresh();
    }

    public void OnClickBulletViewer(){
        Cannon playerCannonComponent = m_playerObjectInstance.GetComponent<Cannon>();
        playerCannonComponent.ChangeBulletAttribute();
        UIViewerBullet uiViewerBullet = m_uiViewerBulletInstance.GetComponent<UIViewerBullet>();
        uiViewerBullet.Refresh();
    }    

    [Header("UIの操作対象")]
    public GameObject m_playerObjectInstance;
    public GameObject m_uiViewerWeaponInstance;
    public GameObject m_uiViewerBulletInstance;
    
}
