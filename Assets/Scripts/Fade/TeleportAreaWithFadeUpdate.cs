using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportAreaWithFadeUpdate : TeleportationArea
{
    
    public ScreenFade screenFade = null;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnSelectEntered)
            StartCoroutine(FadeSequence(base.OnSelectEntered, args));
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnSelectExited)
            StartCoroutine(FadeSequence(base.OnSelectExited, args));
    }
    protected override void OnActivated(ActivateEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnActivated)
            StartCoroutine(FadeSequence(base.OnActivated, args));
    }
    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnDeactivated)
            StartCoroutine(FadeSequence(base.OnDeactivated, args));
    }
    private IEnumerator FadeSequence<T>(UnityAction<T> action, T args)
        where T : BaseInteractionEventArgs
    {
        // Fade to black
        float duration = screenFade.FadeIn();
        // Wait, then teleport
        yield return new WaitForSeconds(duration);
        action.Invoke(args);
        // Fade to clear
        screenFade.Fadeout();
    }
    private void OnValidate()
    {
        
        if (!screenFade)
            screenFade = FindObjectOfType<ScreenFade>();
    }
    
}
