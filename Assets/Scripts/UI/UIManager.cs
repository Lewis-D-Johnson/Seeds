using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			if (instance != this)
			{
				Destroy(instance);
			}

			instance = this;
		}
		else
		{
			instance = this;
		}
	}

	public bool showingHighlightUI = false;

	[Header("UI")]
	public GameObject CurrentHighlight;
	public Image HighlightImage;
	public Text HighlightName;
	public Text HighlightDescription;

	void Start()
    {
        
    }
	
    void Update()
    {
        
    }

	public void ShowHighlightUI(Sprite thisIcon, string Name, string Description)
	{
		CurrentHighlight.SetActive(true);   //Give this an animation so it looks better

		if (thisIcon != null)
			HighlightImage.sprite = thisIcon;

		HighlightName.text = Name;
		HighlightDescription.text = Description;

		showingHighlightUI = true;
	}

	public void CloseHighlightUI()
	{
		CurrentHighlight.SetActive(false);   //Give this an animation so it looks better

		showingHighlightUI = false;
	}
}
