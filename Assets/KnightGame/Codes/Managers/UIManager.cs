using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace Dante.Managers.UI {
	public class UIManager : MonoBehaviour
	{
		#region References

		[SerializeField] protected TMP_Dropdown moveDropdown;
		[SerializeField] protected TMP_Dropdown turnDropdown;

		[SerializeField] protected DynamicMoveProvider moveProvider;
		[SerializeField] protected TeleportationArea teleportationArea;

		[SerializeField] protected ActionBasedContinuousTurnProvider continuousTurnProvider;
		[SerializeField] protected ActionBasedSnapTurnProvider snapTurnProvider;

		
		#endregion
		
		#region RuntimeVariables
		
		
		
		#endregion
	
		#region UnityMethods
		
		
		
		#endregion
		
		#region PublicMethods
		
		public void QuitApplication()
		{
			Application.Quit();
		}

		public void PlayButton()
		{
			if(moveDropdown.value == 0)
			{
				moveProvider.gameObject.SetActive(true);
			}
			else
			{
				teleportationArea.enabled = true;
				moveProvider.gameObject.SetActive(false);
            }
            if (turnDropdown.value == 0)
			{
				continuousTurnProvider.enabled = true;
			}
			else
			{
				snapTurnProvider.enabled = true;
			}
		}
		
		#endregion
		
		#region LocalMethods
		
		
		
		#endregion
		
		#region GettersSetters
		
		
		
		#endregion
	}
}
