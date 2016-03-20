using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	
	static Pauser singletonPauser;

	void Start()
	{
		if(Pauser.singletonPauser)
		{
			Destroy(this);
		}
		else
		{
			Pauser.singletonPauser = this;
		}
	}

	public static void Pause()
	{
		Time.timeScale = 0.0f;
	}

	public static void UnPause()
	{
		Time.timeScale = 1.0f;
	}

	public static bool isPaused
	{
		get
		{
			return Time.timeScale == 0.0f;
		}

		set
		{
			bool paused = Pauser.isPaused;
			if(value != paused)
			{
				if (paused)
				{
					Pauser.UnPause();
				}
				else
				{
					Pauser.Pause();
				}
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(Pauser.isPaused)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if (Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
			Pauser.isPaused = ! Pauser.isPaused;
		}
	}

}
