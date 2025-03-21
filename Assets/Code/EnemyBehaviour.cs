using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    NavMeshAgent m_agent;
    Animator m_animator;
    Collider m_collider;
    Rigidbody m_rigidbody;


    private void OnEnable() {
        if (m_agent != null) {
            m_agent.enabled = true;
        }
        if(m_animator != null) {
            m_animator.enabled = true;
        }
        if(m_collider != null) {
            m_collider.enabled = true;
        }
        if(m_rigidbody != null) {
            m_rigidbody.isKinematic = false;
        }
    }

    private void Awake() {
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        m_collider = GetComponent<Collider>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (m_agent.isActiveAndEnabled) {
            m_agent.SetDestination(m_playerTransform.position);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Sword")) {
            m_agent.ResetPath();
            m_agent.enabled = false;
            m_animator.enabled = false;
            m_collider.enabled = false;
            m_rigidbody.isKinematic = true;

            Invoke("SetInactiveEnemy", 3.5f);
        }
    }

    protected void SetInactiveEnemy() {
        gameObject.SetActive(false);
    }

    #region GettersSetters

    public Transform PlayerTransform {
        set { m_playerTransform = value; }
        
    }

    #endregion
}
