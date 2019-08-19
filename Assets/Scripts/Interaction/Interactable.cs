using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
	public string Name;			//Change these into their own class eventually
	[TextArea(1, 20)]
	public string Description;  //Change these into their own class eventually

	public UnityEvent OnInteracted;
	public UnityEvent OnHighlight;
	public UnityEvent OnToggledOn;
	public UnityEvent OnToggledOff;

	public bool IsToggleable = false;
	public bool ToggledState = false;

	public void Interact()
	{
		if(!IsToggleable)
			OnInteracted.Invoke();
		else
		{
			ToggledState = !ToggledState;

			if (ToggledState)
				OnToggledOn.Invoke();
			else
				OnToggledOff.Invoke();
		}
	}

	public void Hightlight()
	{
		OnHighlight.Invoke();

		UIManager.instance.ShowHighlightUI(null, Name, Description);
	}
}
