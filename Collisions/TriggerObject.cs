using UnityEngine;
using System.Collections;

namespace mnUtilities.Collisions
{
	public class TriggerObject : MonoBehaviour 
	{
		/// <summary>
		/// Enable flag to disables the component(s) at startup. All these component(s) are re-enabled when a trigger (collision) is registered.
		/// </summary>
		[Tooltip("Enable flag to disables the object(s) at startup. All these object(s) are re-enabled when a trigger (collision) is registered.")]
		public bool DisableOnStartup = true;

		/// <summary>
		/// Component(s) which will be enabled/re-enabled whenever a trigger (collision) is registered.
		/// </summary>
		[Tooltip("Object(s) which will be enabled/re-enabled whenever a trigger (collision) is registered.")]
		public GameObject []EnableObjects = null;

		private bool m_isTriggered = false;

		/// <summary>
		/// Internal Unity method.
		/// This method is called everytime the compnent is enalbed/re-enabled.
		/// The method sets all values to their default values.
		/// </summary>
		void OnEnable()
		{
			if(DisableOnStartup == true)
				ToggleTrigger(false);
		}

		/// <summary>
		/// Toggles the component to activate its trigger or to disable the trigger.
		/// Activating the object(s) and component(s) can only be done once. If the object(s) and component(s) are already
		/// activated by this trigger when this method is called, then the method is ignored. 
		/// The object(s) and component(s) needs to be resetted/disabled (ex. by calling this method with a 'false' parameter) before they can be triggered/enabled once more.
		/// </summary>
		/// <param name="isActive">Set to true to activate trigger. Set to false to reset/disable the triggere object(s) and component(s).</param>
		public void ToggleTrigger(bool isActive)
		{
			if(m_isTriggered == false)
			{
				int objectCount = EnableObjects.Length;
				for(int i = 0; i < objectCount; ++i)
				{
					EnableObjects[i].SetActive(isActive);
				}
			}

			m_isTriggered = isActive;
		}

		/// <summary>
		/// Internal Unity method.
		/// This method is called whenever a collision is registered.
		/// This method activates the trigger functionality.
		/// </summary>
		/// <param name="collision">Collision data about the other colliding object.</param>
		void OnCollisionEnter(Collision collision) 
		{
			ToggleTrigger(true);
		}

		/// <summary>
		/// Internal Unity method.
		/// This method is called whenever a collision is registered.
		/// This method activates the trigger functionality.
		/// </summary>
		/// <param name="other">Collision data about the other colliding object.</param>
		void OnTriggerEnter(Collider other)
		{
			ToggleTrigger(true);
		}
	}
}
