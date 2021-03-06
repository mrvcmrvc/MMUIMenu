﻿using UITweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHorizontalAccordionController : UIBehaviourControllerBase<UIHorizontalAccordionBehaviour>
{
    [Range(0f, 1f)]
    public float MinSize;
    public float Duration;
    public int DefaultOpenedPage;
    public RectTransform AccordionContainer;
    public UITweeningEaseEnum Ease;

    protected override void Awake()
    {
        base.Awake();

        if (DefaultOpenedPage >= BehaviourList.Count)
            DefaultOpenedPage = 0;

        BehaviourList.ForEach(b => b.ResetUI(false, MinSize));
        BehaviourList[DefaultOpenedPage].ResetUI(true, 1 - (MinSize * (BehaviourList.Count - 1)));
    }

    public override void OnSubContainerPressDown(UIHorizontalAccordionBehaviour interactedContainer, PointerEventData eventData)
    {
        float expandedHeight = 1 - (MinSize * (BehaviourList.Count - 1));

        interactedContainer.Activate(expandedHeight, Duration, Ease);

        BehaviourList.FindAll(b => b != interactedContainer).ForEach(b => b.Deactivate(MinSize, Duration, Ease));

        base.OnSubContainerPressDown(interactedContainer, eventData);
    }
}
