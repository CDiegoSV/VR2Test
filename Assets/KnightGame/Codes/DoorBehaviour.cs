using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Dante {
	public class DoorBehaviour : MonoBehaviour
	{
        #region References

        [SerializeField] protected Collider plugCollider;
        [SerializeField] protected GameObject gate;
        [SerializeField] protected AnimationClip gateAnimation;

        #endregion

        #region Runtime Variables

        protected XRSocketInteractor socketInteractor;

        protected bool plugEntered;

        protected Animator gateAnimator;

        #endregion

        #region Unity Methods

        private void Start()
        {
            socketInteractor = gameObject.GetComponent<XRSocketInteractor>();
            gateAnimator = gate.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other == plugCollider)
            {
                plugEntered = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == plugCollider)
            {
                plugEntered = false;
            }
        }

        #endregion

        #region PublicMethods

        public void OnSelectEntered()
        {
            if (plugEntered)
            {
                gateAnimator.SetBool("Open", true);
                StartCoroutine(SetGateY());
            }
        }

        #endregion

        #region LocalMethods

        protected IEnumerator SetGateY()
        {
            yield return new WaitForSeconds(gateAnimation.length);
            gate.transform.position = new Vector3(gate.transform.position.x, 2.0494f, gate.transform.position.z);
        }

        #endregion

        #region GettersSetters



        #endregion
    }
}
