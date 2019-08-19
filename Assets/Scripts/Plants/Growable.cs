using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
	[Range(0, 100)]
	public float GrowthPercentage;
	public float GrowthSpeed;

    void Start()
    {
        
    }
	
    void Update()
    {
		GrowthPercentage += Time.deltaTime / GrowthSpeed;
		transform.localScale = new Vector3(GrowthPercentage/100, GrowthPercentage/100, GrowthPercentage/100);
    }
}
