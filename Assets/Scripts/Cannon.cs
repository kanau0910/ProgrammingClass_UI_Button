using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_bulletParent = GameObject.Find("BulletParent");
        m_bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        m_homingBulletPrefab = Resources.Load<GameObject>("Prefabs/HomingBullet");
        m_weaponType = E_WeaponType.eSingleShoot;
    }

    // Update is called once per frame
    void Update()
    {
        m_targetObject = GetTargetObject();

        this.transform.LookAt(m_targetObject.transform, new Vector3( 0, 0,- 1.0f));
    }

    GameObject GetTargetObject()
    {
        return GameObject.Find("TargetObject");
    }

    void Shoot(){
        GameObject bulletInstance = Instantiate(m_bulletPrefab);
        bulletInstance.transform.position = this.transform.position;
        bulletInstance.transform.SetParent(m_bulletParent.transform);
        bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, Vector3.zero);
    }

    void VariableWayShoot(int wayNum, float startEulerOffset, float wayMargine){
        for(int i = 0; i < wayNum; i++){
            GameObject bulletInstance = Instantiate(m_bulletPrefab);
            bulletInstance.transform.position = this.transform.position;
            bulletInstance.transform.SetParent(m_bulletParent.transform);

            Vector3 targetDirection = m_targetObject.transform.position - bulletInstance.transform.position;
            targetDirection = Quaternion.Euler(0, 0, startEulerOffset + wayMargine * i) * targetDirection;
            bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, targetDirection);
        }
    }

    void VariableWayHomingShoot(int wayNum, float startEulerOffset, float wayMargine){
        for(int i = 0; i < wayNum; i++){
            GameObject bulletInstance = Instantiate(m_homingBulletPrefab);
            bulletInstance.transform.position = this.transform.position;
            bulletInstance.transform.SetParent(m_bulletParent.transform);

            Vector3 targetDirection = m_targetObject.transform.position - bulletInstance.transform.position;
            targetDirection = Quaternion.Euler(0, 0, startEulerOffset + wayMargine * i) * targetDirection;
            bulletInstance.GetComponent<Bullet>().Targeting(m_targetObject, targetDirection);
        }
    }    

    public void OnClickShootUIButton(){
        switch(m_weaponType){
            case E_WeaponType.eSingleShoot:
                VariableWayShoot(1, 0.0f, 30.0f);
                break;
            case E_WeaponType.e3WayShoot:
                VariableWayShoot(3, -30.0f, 30.0f);
                break;
            case E_WeaponType.e5WayShoot:
                VariableWayShoot(5, -60.0f, 30.0f);
                break;
        }
    }

    public E_WeaponType GetWeaponType(){
        return m_weaponType;
    }

    public void ChangeWeaponType(){
        int nextWeaponTypeId = (int)m_weaponType + 1;
        if(nextWeaponTypeId >= (int)(E_WeaponType.eNum)){
            nextWeaponTypeId = (int)(E_WeaponType.eSingleShoot);
        }
        m_weaponType = (E_WeaponType)nextWeaponTypeId;
    }

    GameObject m_targetObject;
    GameObject m_bulletParent;
    GameObject m_bulletPrefab;
    GameObject m_homingBulletPrefab;

    public enum E_WeaponType{
        eSingleShoot = 0,
        e3WayShoot,
        e5WayShoot,
        eNum
    }
    [SerializeField]
    E_WeaponType m_weaponType;
}
