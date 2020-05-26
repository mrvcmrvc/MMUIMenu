﻿using MVVM;
using UnityEngine;

public class InteractableTestPLD : IPLDBase
{
    public bool IsButtonActive { get; private set; }

    public InteractableTestPLD(bool isButtonActive)
    {
        IsButtonActive = isButtonActive;
    }
}

public class InteractableTestView : InteractableViewBase<InteractableTestPLD, bool>
{
    protected override string _viewModelMethodName { get { return "OnInteractableTestViewPressed"; } }

    protected override void ParsePLD(InteractableTestPLD pld)
    {
        Debug.Log("Updating Interactable View");
    }

    protected override void OnVMPreActivationCustomActions()
    {
        //Activate button or stuff
    }

    protected override void OnVMPreDeactivationCustomActions()
    {
        // Deactivate button or stuff
    }

    protected override void RegisterEventsCustomActions()
    {
        UpdateViewModel(true);
    }

    protected override void UnregisterEventsCustomActions()
    {
    }
}
