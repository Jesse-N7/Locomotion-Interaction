using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenFadePass : ScriptableRenderPass
{

        public FadeSettings settings = null;

        public ScreenFadePass(FadeSettings newSettings)
        {
        settings = newSettings;
        renderPassEvent = newSettings.renderPassEvent;  //
        }
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData) //
    {
        CommandBuffer command = CommandBufferPool.Get(settings.profilerTag);  //instructions to give to Unity's renderer
       
        RenderTargetIdentifier source = BuiltinRenderTextureType.CameraTarget; //this will be rendered to the camera
        RenderTargetIdentifier destination = BuiltinRenderTextureType.CurrentActive; //

        command.Blit(source, destination, settings.runTimeMaterial); //
        context.ExecuteCommandBuffer(command);

        
        CommandBufferPool.Release(command); //this will end the command, or "release" it
    }
}






