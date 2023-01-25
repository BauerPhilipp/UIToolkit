using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class StarController : VisualElement
{

    public new class UxmlFactory : UxmlFactory<StarController, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription starsAttribute = new UxmlIntAttributeDescription() { name = "Stars"};

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            (ve as StarController).Stars = starsAttribute.GetValueFromBag(bag, cc);
        }
    }

    int stars;
    public int Stars
    {
        get => stars;
        set {
            stars = value;
            UpdateStars();
        }
    }

    const string starsStyleSheet = "Stylesheet_Stars";
    const string ussContainer = "starsContainer";
    const string ussInnerStars = "inner_stars";
    const string ussOuterStars = "outer_stars";

    List<VisualElement> outerStarsList = new List<VisualElement>();
    List<VisualElement> innerStarsList = new List<VisualElement>();


    public StarController()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(starsStyleSheet));

        VisualElement container = new VisualElement();
        container.name = "StarsContainer";
        container.AddToClassList(ussContainer);

        hierarchy.Add(container);

        CreateStarLists(container);
        
    }

    void CreateStarLists(VisualElement container)
    {
        for (int i = 0; i < 7; i++)
        {
            VisualElement outerStarTemp = new VisualElement();
            outerStarTemp.name = "OuterStar";
            outerStarTemp.AddToClassList(ussOuterStars);
            outerStarsList.Add(outerStarTemp);

            container.Add(outerStarTemp);

            VisualElement innerStarTemp = new VisualElement();
            innerStarTemp.name = "InnerStar";
            innerStarTemp.AddToClassList(ussInnerStars);
            innerStarsList.Add(innerStarTemp);
            outerStarTemp.Add(innerStarTemp);            
        }
    }

    public void UpdateStars()
    {
        DisableOuterStars();
        innerStarsList.Take(stars)
            .ToList()
            .ForEach(elem => elem.style.visibility = Visibility.Visible);
    }
    void DisableOuterStars()
    {
        innerStarsList.ForEach(elem => elem.style.visibility = Visibility.Hidden);
    }
}
