using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Pixelplacement;


public class ScreenFade : MonoBehaviour


{

    public ForwardRendererData rendererData = null; //ref to render data

    [Range(0, 1)] public float alpha = 1.0f;
    [Range(0, 5)] public float duration = 0.5f;

    public Material fadeMaterial = null;  
    // Start is called before the first frame update
    void Start()
    {
        SetupFadeFeature(); //this is what the function will be called
    }

    public void SetupFadeFeature()
    {
        ScriptableRendererFeature feature = rendererData.rendererFeatures.Find(item => item is ScreenFadeFeature);

        if (feature is ScreenFadeFeature screenFade)
        {
            fadeMaterial = Instantiate(screenFade.settings.material);
            screenFade.settings.runTimeMaterial = fadeMaterial;
        }
    }

    public float FadeIn()
    {
        Tween.ShaderFloat(fadeMaterial, "_Alpha", 1, duration, 0);  //this will fade to black 
        return duration;
    }

    public float Fadeout()
    {
        Tween.ShaderFloat(fadeMaterial, "_Alpha", 0, duration, 0); // this will fade to clear. 
        return duration;
    }

}
