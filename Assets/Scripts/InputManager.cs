using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

		
		public static Vector3 positionOfLastTap, currentCursorPosition;
		
		
		public delegate void IsHeldDown();
		public static event IsHeldDown HeldDown; //event for when the user holds right click down
		
		public delegate void IsTapped();
		public static event IsTapped Tapped; //event for when the user taps and does not hold
		
		public delegate void IsReleaseHold();
		public static event IsReleaseHold ReleaseHold; //event for when the user releases from slowmo/hold
		
		public float timeRequiredToTriggerHold;
		bool holdCounter = false;
		float timeOfClick;
		float holdTime; //time that the mouse or finger has been held down
		
		void OnEnable()
		{
			GameManager.OnHoldingDown += EnableCounter;
			GameManager.OnRelease += DisableCounter;
		}
		
		void OnDisable()
		{
			GameManager.OnHoldingDown -= EnableCounter;
			GameManager.OnRelease -= DisableCounter;
		}
		
		
		#if UNITY_EDITOR
		
		public void EnableCounter() //start timer to help determine whether has tapped or is holding down
		{
			if (GameManager.s_instance.currentGameState == GameState.Playing) {
				positionOfLastTap = Input.mousePosition;
				timeOfClick = Time.time;
				holdCounter = true;
			}
			

		else {
			//for when you are not exploring the room you are in a menu and only taps exist
			positionOfLastTap = Input.mousePosition;
			Tapped();
		}
		}
		
		public void DisableCounter()
		{
				if (GameManager.s_instance.currentGameState == GameState.Playing) {

						if (holdTime <= timeRequiredToTriggerHold) {
								if (Tapped != null) {
										Tapped ();
								}
						} else {
								if (ReleaseHold != null) {
										ReleaseHold ();
								}
						}
						holdCounter = false;
				}
		}
		void Update()
		{
		if (GameManager.s_instance.currentGameState == GameState.Playing) {
					currentCursorPosition = Input.mousePosition; 
					if (holdCounter) {								//games it so tapping is different from holding down
							holdTime = Time.time - timeOfClick;
							if (holdTime > timeRequiredToTriggerHold) {
									holdCounter = false;
									if (HeldDown != null) {
											HeldDown ();
									}
							}
					}
			}
		}
		
		#elif UNITY_IPHONE
		
		public void EnableCounter()
		{
			PositionOfLastTap = Camera.main.ScreenToWorldPoint(
				new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, PlayerController.cameraDistance));
			timeOfClick = Time.time;
			holdCounter = true;
		}
		
		public void DisableCounter()
		{
			if (holdTime <= timeRequiredToTriggerHold)
			{
				if ( Tapped != null )
				{
					Tapped();
				}
			}
			else
			{
				if ( ReleaseHold != null )
				{
					ReleaseHold();
				}
			}
			holdCounter = false;
		}
		
		
		
		void Update()
		{
			
			if (holdCounter)
			{
				holdTime = Time.time - timeOfClick;
				if (holdTime > timeRequiredToTriggerHold)
				{
					holdCounter = false;
					if ( HeldDown != null ) 
					{
						HeldDown();
					}
				}
			}
		}
		
		
		#endif
}