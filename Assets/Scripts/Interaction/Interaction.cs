using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
	public bool canInteract = true;
	public float interactDistance = 3f;
	public LayerMask interactLM;
	RaycastHit hit;

	Transform Camera;

	public Interactable thisInteractable;

    void Start()
    {
		Camera = GetComponentInChildren<Camera>().transform;
    }
	
    void Update()
    {
		if (canInteract)
		{
			if (Physics.Raycast(Camera.position, Camera.forward, out hit, 3f, interactLM))
			{
				if (hit.transform.GetComponent<Interactable>() != null)
				{
					Interactable inter = hit.transform.GetComponent<Interactable>();

					inter.Hightlight();
					thisInteractable = inter;
				}
				else
				{
					thisInteractable = null;
				}
			}
			else
			{
				thisInteractable = null;
			}

			if (Input.GetButtonDown("Interact"))
			{
				if (thisInteractable != null)
				{
					thisInteractable.Interact();
				}
			}
		}
		else
		{
			thisInteractable = null;
		}

		if (UIManager.instance.showingHighlightUI && thisInteractable == null)
			UIManager.instance.CloseHighlightUI();
	}
}
