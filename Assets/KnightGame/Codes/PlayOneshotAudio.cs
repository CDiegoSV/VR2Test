using UnityEngine;

namespace Dante {
	public class PlayOneshotAudio : MonoBehaviour
	{
		#region References

		
		[SerializeField] protected AudioClip audioClip;

		#endregion

		#region RuntimeVariables

		protected AudioSource audioSource;

        #endregion

        #region UnityMethods

        private void Start()
        {
			audioSource = gameObject.GetComponent<AudioSource>();
        }

        #endregion

        #region PublicMethods

        public void PlayOneShotAudio()
		{
			audioSource.PlayOneShot(audioClip);
		}
		
		#endregion
		
		#region LocalMethods
		
		
		
		#endregion
		
		#region GettersSetters
		
		
		
		#endregion
	}
}
