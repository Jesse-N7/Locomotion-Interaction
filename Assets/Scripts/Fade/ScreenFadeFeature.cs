using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenFadeFeature : ScriptableRendererFeature
{
    public FadeSettings settings = null;
    public ScreenFadePass renderPass = null;

    public override void Create()
    {
        renderPass = new ScreenFadePass(settings); //creating a new screen fade pass
    }


    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (settings.AreValid())
            renderer.EnqueuePass(renderPass); //making sure the settings are valid before adding to the pass
    }
}

public class FadeSettings
{
    public bool isEnabled = true;
    public string profilerTag = "ScreenFade";

    public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
    public Material material = null;

    public Material runTimeMaterial = null;  //

    public bool AreValid()
    {
        return (runTimeMaterial != null) && isEnabled;
    }
}
