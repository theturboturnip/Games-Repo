using UnityEngine;
using System.Collections;

//This script doesn't need to be attached to something in the scene to work.

public static class GraphicsSettings{
	public static int width=640,height=480,refreshRate=60,vsyncRate=1,antiAliasingLevel=0,queuedFrames=0,masterTextureLimit=0,shadowCascades=0;
	public static AnisotropicFiltering anisotropicFilteringMode=AnisotropicFiltering.Disable;
	public static bool fullScreen=true,realTimeReflections=true,softVegetation=false;
	public static float shadowDistance=150f,brightness=1f;
	public static Color ambientColor=Color.white;

	public static void SetResolution(int newWidth,int newHeight){
		//Give a width and a height to be used as the size of the screen.
		width=newWidth;
		height=newHeight;	
	}

	public static void SetResolution(int[] resolution){
		//Give an array of two integers to be used as the width and the height of the screen respectively.
		if(!fullScreen){
			width=resolution[0];
			height=resolution[1];
		}
	}

	public static void SetResolution(Resolution resolution){
		//Give a resolution object to use as the new resolution. Refresh rate is also modified with this version of the function, 
		//because it is specified in the resolution object.
		width=resolution.width;
		height=resolution.height;
		SetRefreshRate(resolution.refreshRate);
	}

	public static void SetShadowCascades(int level){
		//Give a level between 0 and 2 to set the number of different shadowmap resolutions.
		shadowCascades=level*2;
	}

	public static void SetFullscreen(bool newFullscreen){
		//Give whether the application should be in fullscreen.
		fullScreen=newFullscreen;
		if(fullScreen){
			//Set the resolution to highest available
			SetResolution(Screen.resolutions[Screen.resolutions.Length-1]);
		}
	}

	public static void SetRefreshRate(int newRefreshRate){
		//Give refresh rate to be used. If unsupported, highest possible will be used.
		refreshRate=newRefreshRate;
	}

	public static void SetTriBuffering(bool shouldTriBuffer){
		//Give if tri-buffering should be enabled.
		queuedFrames=0;
		if(shouldTriBuffer)
			queuedFrames=3;
	}

	public static void SetVSync(bool shouldVSync){
		//Give if VSync should be enabled.
		vsyncRate=0;
		if(shouldVSync)
			vsyncRate=1;
	}

	public static void SetAnisotropicFilteringMode(bool enable,bool forceOnAll=false){
		//Give whether anisotropic filtering should be enabled, and if it should be forced on all textures.
		anisotropicFilteringMode=AnisotropicFiltering.Disable;
		if(enable){
			anisotropicFilteringMode=AnisotropicFiltering.Enable;
			if(forceOnAll)
				anisotropicFilteringMode=AnisotropicFiltering.ForceEnable;
		}		
	}

	public static void SetBrightness(float newBrightness){
		//This can be anything, but numbers between 0 and 1 are reccomended as anything beyond might not work
		brightness=newBrightness;
	}

	public static void SetAmbientColor(Color newAmbientColor){
		//This is the color ambient light uses. Changing the brightness changes the intensity of this color, so it is recomended to not use both.
		ambientColor=newAmbientColor;
	}

	public static void SetAALevel(int newAALevel){
		//Give the MSAA level to be used. Should be 0,2,4,or 8, anything else will be rounded to one of those.
		if(newAALevel<=0)
			antiAliasingLevel=0;
		else if (newAALevel>=8)
			antiAliasingLevel=8;
		else if (newAALevel%2==1)
			antiAliasingLevel=newAALevel-1;
		else
			antiAliasingLevel=newAALevel;
	}

	public static void SetRealTimeReflections(bool shouldHaveReflections){
		//Give true if reflections should be rendered in real time.
		realTimeReflections=shouldHaveReflections;
	}

	public static void SetTextureQuality(float quality){
		//Give quality as fractions, so 0.5 for 1/2 quality, 0.25 for 1/4 quality.
		masterTextureLimit=(int)(1/quality)-1;
	}

	public static void SetShadowDistance(float distance){
		//Give distance at which shadows can be rendered.
		shadowDistance=distance;
	}

	public static void SetSmoothVegetation(bool shouldHaveSoftVegetation){
		//Give whether vegetation should be smoothed.
		softVegetation=shouldHaveSoftVegetation;
	}

	public static void Apply(){
		//Apply graphical settings to game, and save these settings to be used upon next startup.
		Screen.SetResolution(width,height,fullScreen,refreshRate);
		QualitySettings.antiAliasing=antiAliasingLevel;
		QualitySettings.vSyncCount=vsyncRate;
		QualitySettings.maxQueuedFrames=queuedFrames;
		QualitySettings.anisotropicFiltering=anisotropicFilteringMode;
		QualitySettings.realtimeReflectionProbes=realTimeReflections;
		QualitySettings.masterTextureLimit=masterTextureLimit;
		QualitySettings.shadowDistance=shadowDistance;
		QualitySettings.softVegetation=softVegetation;
		QualitySettings.shadowCascades=shadowCascades;
		RenderSettings.ambientLight=ambientColor*brightness;
		//Save brightness to load from later
		PlayerPrefs.SetFloat("Brightness",brightness);
	}

	public static void LoadFromCurrent(){
		//Load current graphical settings
		width=Screen.width;
		height=Screen.height;
		fullScreen=Screen.fullScreen;
		refreshRate=Screen.currentResolution.refreshRate;
		antiAliasingLevel=QualitySettings.antiAliasing;
		vsyncRate=QualitySettings.vSyncCount;
		queuedFrames=QualitySettings.maxQueuedFrames;
		anisotropicFilteringMode=QualitySettings.anisotropicFiltering;
		realTimeReflections=QualitySettings.realtimeReflectionProbes;
		masterTextureLimit=QualitySettings.masterTextureLimit;
		shadowDistance=QualitySettings.shadowDistance;
		softVegetation=QualitySettings.softVegetation;
		shadowCascades=QualitySettings.shadowCascades;
		brightness=PlayerPrefs.GetFloat("Brightness",1f);
		ambientColor=RenderSettings.ambientLight/brightness;
	}
}
