using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Destroy(this.gameObject, m_lifeTimeSecond);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        m_moveDistance = m_moveDirection * m_speed * Time.deltaTime;

        this.transform.position += m_moveDistance;
    }

    public void Targeting(GameObject target, Vector3 targetDirection)
    {
        m_targetObject = target;

        if(targetDirection.magnitude < 0.01f){
            m_moveDirection = target.transform.position - this.transform.position;
            m_moveDirection = m_moveDirection.normalized;
        }else{
            m_moveDirection = targetDirection.normalized;
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.transform.name == "HitModel_Enemy"){
            GameObject TargetObject = other.transform.parent.gameObject;
            Enemy enemyComponent = TargetObject.GetComponent<Enemy>();
            enemyComponent.TakeDamage(-1);

            Destroy(this.gameObject);
        }
    }

    public float m_speed;
    public float m_lifeTimeSecond;
    protected GameObject m_targetObject;
    [SerializeField]
    protected Vector3 m_moveDirection;
    [SerializeField]
    protected Vector3 m_moveDistance;
}
