using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Example : MonoBehaviour {
	Text fpsLabel;
	bool fullScreenToggled=false,shadowDistanceChanged=false,AAChanged=false,
		 anisotropicChanged=false,reflectionsChanged=false,textureQualityChanged=false,
		 vsyncChanged=false,canApply=false;
	void Start () {
		//Tell GraphicsSettings to load the current settings
		//The sliders in the example won't be set to current
		GraphicsSettings.LoadFromCurrent();
		GraphicsSettings.SetRefreshRate(120);
		fpsLabel=GameObject.Find("TestMenu/FPS").GetComponent<Text>();
		GameObject.Find("TestMenu/Apply").GetComponent<Button>().interactable=false;

	}
	void Update(){
		fpsLabel.text="FPS: "+(int)(1/Time.smoothDeltaTime);
		if(!canApply){
			canApply=fullScreenToggled&&shadowDistanceChanged&&AAChanged&&anisotropicChanged&&reflectionsChanged&&textureQualityChanged&&vsyncChanged;
			if(canApply)
				GameObject.Find("TestMenu/Apply").GetComponent<Button>().interactable=true;
		}
	}
	public void ToggleFullscreen(GameObject text){
		fullScreenToggled=true;
		GraphicsSettings.SetFullscreen(!GraphicsSettings.fullScreen);
		text.GetComponent<Text>().text="Fullscreen: "+GraphicsSettings.fullScreen;
	}

	public void SetResolution(int xSize,int ySize){
		GraphicsSettings.SetResolution(xSize,ySize);
	}

	public void SetResolutionWithArray(int[] resolution){
		//GraphicsSettings.SetResolution works with an integer array or two integers as arguments.
		GraphicsSettings.SetResolution(resolution);
	}
	public void ChangeResolution(float sliderProgress){
		GraphicsSettings.SetResolution((int)Math.Floor(1920*sliderProgress),(int)Math.Floor(1080*sliderProgress));
	}
	public void SetShadowDistance(float sliderProgress){
		GraphicsSettings.SetShadowDistance(sliderProgress*50f);
		shadowDistanceChanged=true;
	}
	public void SetAALevel(float sliderProgress){
			GraphicsSettings.SetAALevel((int)Math.Pow(2,sliderProgress));
			AAChanged=true;
	}
	public void SetAnisotropicFilteringMode(float sliderProgress){
		if(sliderProgress==0f)
			GraphicsSettings.SetAnisotropicFilteringMode(false);
		else if (sliderProgress==1f)
			GraphicsSettings.SetAnisotropicFilteringMode(true);
		else
			GraphicsSettings.SetAnisotropicFilteringMode(true,true);
		anisotropicChanged=true;
	}
	public void UpdateAnisotropicFilteringText(GameObject text){
		text.GetComponent<Text>().text="Anisotropic Filtering Mode: "+GraphicsSettings.anisotropicFilteringMode;
	}
	public void ToggleRealTimeReflections(GameObject text){
		reflectionsChanged=true;
		GraphicsSettings.SetRealTimeReflections(!GraphicsSettings.realTimeReflections);
		text.GetComponent<Text>().text="Real Time Reflections: "+GraphicsSettings.realTimeReflections;
	}
	public void ToggleVSync(GameObject text){
		vsyncChanged=true;
		GraphicsSettings.SetVSync(!(GraphicsSettings.vsyncRate==1));
		text.GetComponent<Text>().text="VSync: "+(GraphicsSettings.vsyncRate==1);
	}
	public void UpdateResolutionText(GameObject text){
		text.GetComponent<Text>().text="Resolution: "+GraphicsSettings.width+"x"+GraphicsSettings.height;
	}
	public void SetTextureQuality(float sliderProgress){
		textureQualityChanged=true;
		GraphicsSettings.SetTextureQuality(1/(float)Math.Pow(2,sliderProgress));
	}
	public void UpdateTextureQualityText(GameObject text){
		text.GetComponent<Text>().text="Texture Quality: 1/"+(GraphicsSettings.masterTextureLimit+1);
	}
	public void ApplySettings(){
		GraphicsSettings.Apply();
	}
}
