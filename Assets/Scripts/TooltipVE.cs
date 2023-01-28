using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TooltipVE : VisualElement
{

    public new class UxmlFactory : UxmlFactory<TooltipVE, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription tooltipText = new UxmlStringAttributeDescription() { name = "Tooltip"};

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            (ve as TooltipVE).TooltipText = tooltipText.GetValueFromBag(bag, cc);
        }
    }


    const string styleSheetTooltip = "Stylesheet_tooltip";
    const string ussContainer = "container";
    const string ussLabel = "tooltipLabel";
    Label label = new Label();

    string tooltipText;
    string TooltipText
    {
        get => tooltipText;
        set {
            tooltipText = value;
            label.text = tooltipText;
        }
    }

    public TooltipVE()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(styleSheetTooltip));

        VisualElement container = new VisualElement();
        container.AddToClassList(ussContainer);
        container.name = "Container";
        hierarchy.Add(container);

        label.AddToClassList(ussLabel);
        label.pickingMode = PickingMode.Ignore;
        container.Add(label);

        style.position = Position.Absolute;
        //style.visibility = Visibility.Hidden;
    }

    void TooltipShow(VisualElement target, Vector2 localMousePosition)
    {
        style.visibility = Visibility.Visible;
        
        style.left = target.worldBound.xMin + localMousePosition.x;
        style.top = target.worldBound.yMin + localMousePosition.y - 50;
    }
    void TooltipHide()
    {

    }
}
