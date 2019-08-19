using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generator : Plant
{
	[Header("Stats")]
	public float StoredEnergy;
	public float GenerationRate;

	public float MaxStoredAmount;

	public bool TurnedOn;

	public UnityEvent onToggledOn;
	public UnityEvent onToggledOff;

	Animator anim;

    void Start()
    {
		anim = GetComponent<Animator>();
    }
	
    void Update()
    {
		if (TurnedOn)
		{
			if (anim.GetFloat("TeslaSpinSpeed") < 1)
			{
				anim.SetFloat("TeslaSpinSpeed", anim.GetFloat("TeslaSpinSpeed") + Time.deltaTime / 5);
			}
			else
			{
				anim.SetFloat("TeslaSpinSpeed", 1);
			}

			if (StoredEnergy < MaxStoredAmount)
			{
				StoredEnergy += GenerationRate;
			}
			else
			{
				Toggle();
			}
		}
		else
		{
			if (anim.GetFloat("TeslaSpinSpeed") > 0)
			{
				anim.SetFloat("TeslaSpinSpeed", anim.GetFloat("TeslaSpinSpeed") - Time.deltaTime);
			}
			else
			{
				anim.SetFloat("TeslaSpinSpeed", 0);
			}
		}
    }

	public void Toggle()
	{
		TurnedOn = !TurnedOn;

		if (TurnedOn)
		{
			onToggledOn.Invoke();
			anim.Play("Tesla Spin");
		}
		else
		{
			onToggledOff.Invoke();
		}
	}
}
