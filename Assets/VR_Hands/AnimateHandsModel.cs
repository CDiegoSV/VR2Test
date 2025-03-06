using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dante.VR.Animations {

	#region Class

	[System.Serializable]
	public class AnimateHandsModelOnInput
	{
		public string animationProperty;
		public InputActionProperty actionProperty;
	}

    #endregion
    public class AnimateHandsModel : MonoBehaviour
	{
		#region References

		[SerializeField] List<AnimateHandsModelOnInput> animationInputs;
		[SerializeField] Animator animator;

        #endregion

        #region RuntimeVariables



        #endregion

        #region UnityMethods

        private void Update()
        {
            foreach (AnimateHandsModelOnInput animationInput in animationInputs)
            {
                float actionValue = animationInput.actionProperty.action.ReadValue<float>();
                animator.SetFloat(animationInput.animationProperty, actionValue);
            }
        }

        #endregion

        #region PublicMethods



        #endregion

        #region LocalMethods



        #endregion

        #region GettersSetters



        #endregion
    }
}
