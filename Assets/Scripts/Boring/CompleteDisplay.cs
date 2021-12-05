using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompleteDisplay : MonoBehaviour
{
	public Image Fill;
	//public Image FillRed;
	public static float Progress;
	public static int ProgressPercent;

	public TextMeshProUGUI progressText;

	void Start()
	{
		float CountTrue = 0;
		float TotalCount = 0;
		
		for (var i = 0; i < LevelStorage.TotalLevels.Count; i++)
        {
			for (var j = 0; j < 3; j++)
            {
				if(LevelStorage.TotalLevels[i].Stars[j] == true)
                {
					CountTrue += 1;
				}
				TotalCount += 1;

			}
				

		}
		//Debug.Log(CountTrue + "True");
		//Debug.Log(TotalCount + "Total");
		//Debug.Log((CountTrue / TotalCount) + "Progress");
		Progress = (CountTrue / TotalCount) * 100;
		ProgressPercent = (int)Progress;
		progressText.text = ProgressPercent + "%";

		float ProgressGreen = Progress / 100;
		Fill.fillAmount = ProgressGreen;
		//FillRed.fillAmount = 1 - ProgressGreen;
	}
}
