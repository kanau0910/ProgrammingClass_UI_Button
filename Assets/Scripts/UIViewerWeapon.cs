using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIViewerWeapon : MonoBehaviour
{
    // Start is called before the first frame update
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
        Cannon.E_WeaponType playerCannonWeaponType = playerCannonComponent.GetWeaponType();
        switch(playerCannonWeaponType){
            case Cannon.E_WeaponType.eSingleShoot:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/Weapon_SingleShoot");
                break;
            case Cannon.E_WeaponType.e3WayShoot:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/Weapon_3WayShoot");
                break;
            case Cannon.E_WeaponType.e5WayShoot:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/Weapon_5WayShoot");
                break;
            case Cannon.E_WeaponType.e7WayShoot:
                m_viewerImageComponent.sprite = Resources.Load<Sprite>("ProjectAssets/UI/Weapon_7WayShoot");
                break;
        }
    }

    public GameObject m_playerObjectInstance;
    Image m_viewerImageComponent;
}
