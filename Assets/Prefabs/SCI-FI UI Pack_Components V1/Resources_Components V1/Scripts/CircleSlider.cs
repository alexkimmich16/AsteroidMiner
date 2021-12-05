using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSlider : MonoBehaviour
{
 
     public bool b=true;
	 public Image image;
	 public float speed=0.5f;
	public float Progress;
  
	public Text progress;
  
  void Start()
  {
	  
	image = GetComponent<Image>();
  }
  
    void Update()
    {
		if(b)
		{
			image.fillAmount= Progress;
			if(progress)
			{
				//progress.text = (int)(image.fillAmount*100)+"%";
			}
		
		}
	}
	
	
}
