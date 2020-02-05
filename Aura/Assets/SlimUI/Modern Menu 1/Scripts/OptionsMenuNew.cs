﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuNew : MonoBehaviour {

	public enum Platform {Desktop};
	public Platform platform;

	[Header("VIDEO SETTINGS")]
	public GameObject fullscreentext;
	public GameObject ambientocclusiontext;
	public GameObject shadowofftextLINE;
	public GameObject shadowlowtextLINE;
	public GameObject shadowhightextLINE;
	public GameObject aaofftextLINE;
	public GameObject aa2xtextLINE;
	public GameObject aa4xtextLINE;
	public GameObject aa8xtextLINE;
	public GameObject vsynctext;
	public GameObject motionblurtext;
	public GameObject texturelowtextLINE;
	public GameObject texturemedtextLINE;
	public GameObject texturehightextLINE;
	public GameObject cameraeffectstext; 

	[Header("AUDIO SETTINGS")]
	public GameObject musicSlider;

	[Header("CONTROLS SETTINGS")]
	public GameObject invertmousetext;
	public GameObject sensitivityXSlider;
	public GameObject sensitivityYSlider;
	public GameObject mouseSmoothSlider;

	private float sliderValue = 0.0f;
	private float sliderValueXSensitivity = 0.0f;
	private float sliderValueYSensitivity = 0.0f;
	private float sliderValueSmoothing = 0.0f;
	

	public void Start (){
		// check slider values
		musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
		sensitivityXSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("XSensitivity");
		sensitivityYSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("YSensitivity");
		mouseSmoothSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MouseSmoothing");

		// check full screen
		if(Screen.fullScreen == true){
			fullscreentext.GetComponent<TMP_Text>().text = "on";
		}
		else if(Screen.fullScreen == false){
			fullscreentext.GetComponent<TMP_Text>().text = "off";
		}

		// check shadow distance/enabled
		if(platform == Platform.Desktop){
			if(PlayerPrefs.GetInt("Shadows") == 0){
				QualitySettings.shadowCascades = 0;
				QualitySettings.shadowDistance = 0;
				shadowofftextLINE.gameObject.SetActive(true);
				shadowlowtextLINE.gameObject.SetActive(false);
				shadowhightextLINE.gameObject.SetActive(false);
			}
			else if(PlayerPrefs.GetInt("Shadows") == 1){
				QualitySettings.shadowCascades = 2;
				QualitySettings.shadowDistance = 75;
				shadowofftextLINE.gameObject.SetActive(false);
				shadowlowtextLINE.gameObject.SetActive(true);
				shadowhightextLINE.gameObject.SetActive(false);
			}
			else if(PlayerPrefs.GetInt("Shadows") == 2){
				QualitySettings.shadowCascades = 4;
				QualitySettings.shadowDistance = 500;
				shadowofftextLINE.gameObject.SetActive(false);
				shadowlowtextLINE.gameObject.SetActive(false);
				shadowhightextLINE.gameObject.SetActive(true);
			}
		}


		// check vsync
		if(QualitySettings.vSyncCount == 0){
			vsynctext.GetComponent<TMP_Text>().text = "off";
		}
		else if(QualitySettings.vSyncCount == 1){
			vsynctext.GetComponent<TMP_Text>().text = "on";
		}

		// check mouse inverse
		if(PlayerPrefs.GetInt("Inverted")==0){
			invertmousetext.GetComponent<TMP_Text>().text = "off";
		}
		else if(PlayerPrefs.GetInt("Inverted")==1){
			invertmousetext.GetComponent<TMP_Text>().text = "on";
		}

		// check motion blur
		if(PlayerPrefs.GetInt("MotionBlur")==0){
			motionblurtext.GetComponent<TMP_Text>().text = "off";
		}
		else if(PlayerPrefs.GetInt("MotionBlur")==1){
			motionblurtext.GetComponent<TMP_Text>().text = "on";
		}

		// check ambient occlusion
		if(PlayerPrefs.GetInt("AmbientOcclusion")==0){
			ambientocclusiontext.GetComponent<TMP_Text>().text = "off";
		}
		else if(PlayerPrefs.GetInt("AmbientOcclusion")==1){
			ambientocclusiontext.GetComponent<TMP_Text>().text = "on";
		}

		// check texture quality
		if(PlayerPrefs.GetInt("Textures") == 0){
			QualitySettings.masterTextureLimit = 2;
			texturelowtextLINE.gameObject.SetActive(true);
			texturemedtextLINE.gameObject.SetActive(false);
			texturehightextLINE.gameObject.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Textures") == 1){
			QualitySettings.masterTextureLimit = 1;
			texturelowtextLINE.gameObject.SetActive(false);
			texturemedtextLINE.gameObject.SetActive(true);
			texturehightextLINE.gameObject.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("Textures") == 2){
			QualitySettings.masterTextureLimit = 0;
			texturelowtextLINE.gameObject.SetActive(false);
			texturemedtextLINE.gameObject.SetActive(false);
			texturehightextLINE.gameObject.SetActive(true);
		}
	}

	public void Update (){
		sliderValue = musicSlider.GetComponent<Slider>().value;
		sliderValueXSensitivity = sensitivityXSlider.GetComponent<Slider>().value;
		sliderValueYSensitivity = sensitivityYSlider.GetComponent<Slider>().value;
		sliderValueSmoothing = mouseSmoothSlider.GetComponent<Slider>().value;
	}

	public void FullScreen (){
		Screen.fullScreen = !Screen.fullScreen;

		if(Screen.fullScreen == true){
			fullscreentext.GetComponent<TMP_Text>().text = "on";
		}
		else if(Screen.fullScreen == false){
			fullscreentext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void MusicSlider (){
		PlayerPrefs.SetFloat("MusicVolume", sliderValue);
	}

	public void SensitivityXSlider (){
		PlayerPrefs.SetFloat("XSensitivity", sliderValueXSensitivity);
	}

	public void SensitivityYSlider (){
		PlayerPrefs.SetFloat("YSensitivity", sliderValueYSensitivity);
	}

	public void SensitivitySmoothing (){
		PlayerPrefs.SetFloat("MouseSmoothing", sliderValueSmoothing);
		Debug.Log(PlayerPrefs.GetFloat("MouseSmoothing"));
	}

	public void ShadowsOff (){
		PlayerPrefs.SetInt("Shadows",0);
		QualitySettings.shadowCascades = 0;
		QualitySettings.shadowDistance = 0;
		shadowofftextLINE.gameObject.SetActive(true);
		shadowlowtextLINE.gameObject.SetActive(false);
		shadowhightextLINE.gameObject.SetActive(false);
	}

	public void ShadowsLow (){
		PlayerPrefs.SetInt("Shadows",1);
		QualitySettings.shadowCascades = 2;
		QualitySettings.shadowDistance = 75;
		shadowofftextLINE.gameObject.SetActive(false);
		shadowlowtextLINE.gameObject.SetActive(true);
		shadowhightextLINE.gameObject.SetActive(false);
	}

	public void ShadowsHigh (){
		PlayerPrefs.SetInt("Shadows",2);
		QualitySettings.shadowCascades = 4;
		QualitySettings.shadowDistance = 500;
		shadowofftextLINE.gameObject.SetActive(false);
		shadowlowtextLINE.gameObject.SetActive(false);
		shadowhightextLINE.gameObject.SetActive(true);
	}

	public void vsync (){
		if(QualitySettings.vSyncCount == 0){
			QualitySettings.vSyncCount = 1;
			vsynctext.GetComponent<TMP_Text>().text = "on";
		}
		else if(QualitySettings.vSyncCount == 1){
			QualitySettings.vSyncCount = 0;
			vsynctext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  InvertMouse (){
		if(PlayerPrefs.GetInt("Inverted")==0){
			PlayerPrefs.SetInt("Inverted",1);
			invertmousetext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("Inverted")==1){
			PlayerPrefs.SetInt("Inverted",0);
			invertmousetext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  MotionBlur (){
		if(PlayerPrefs.GetInt("MotionBlur")==0){
			PlayerPrefs.SetInt("MotionBlur",1);
			motionblurtext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("MotionBlur")==1){
			PlayerPrefs.SetInt("MotionBlur",0);
			motionblurtext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  AmbientOcclusion (){
		if(PlayerPrefs.GetInt("AmbientOcclusion")==0){
			PlayerPrefs.SetInt("AmbientOcclusion",1);
			ambientocclusiontext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("AmbientOcclusion")==1){
			PlayerPrefs.SetInt("AmbientOcclusion",0);
			ambientocclusiontext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  CameraEffects (){
		if(PlayerPrefs.GetInt("CameraEffects")==0){
			PlayerPrefs.SetInt("CameraEffects",1);
			cameraeffectstext.GetComponent<TMP_Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("CameraEffects")==1){
			PlayerPrefs.SetInt("CameraEffects",0);
			cameraeffectstext.GetComponent<TMP_Text>().text = "off";
		}
	}

	public void  TexturesLow (){
		PlayerPrefs.SetInt("Textures",0);
		QualitySettings.masterTextureLimit = 2;
		texturelowtextLINE.gameObject.SetActive(true);
		texturemedtextLINE.gameObject.SetActive(false);
		texturehightextLINE.gameObject.SetActive(false);
	}

	public void  TexturesMed (){
		PlayerPrefs.SetInt("Textures",1);
		QualitySettings.masterTextureLimit = 1;
		texturelowtextLINE.gameObject.SetActive(false);
		texturemedtextLINE.gameObject.SetActive(true);
		texturehightextLINE.gameObject.SetActive(false);
	}

	public void  TexturesHigh (){
		PlayerPrefs.SetInt("Textures",2);
		QualitySettings.masterTextureLimit = 0;
		texturelowtextLINE.gameObject.SetActive(false);
		texturemedtextLINE.gameObject.SetActive(false);
		texturehightextLINE.gameObject.SetActive(true);
	}
}