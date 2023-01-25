using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListManager
{

    VisualElement root;
    List<Fraction> fractionsList;

    public ListManager(VisualElement root, List<Fraction> fractionsList)
    {
        this.root = root;
        this.fractionsList = fractionsList;

        CreateListVisual();

    }

    void CreateListVisual()
    {
        ListView list = root.Q<ListView>("MyListView");
        VisualTreeAsset listTemplate = Resources.Load<VisualTreeAsset>("List_Template");

        list.itemsSource = fractionsList;
        list.fixedItemHeight = 60;
        list.makeItem = () => listTemplate.Instantiate();
        list.bindItem = (elem, i) =>
        {
            VisualElement fractionImage = elem.Q("Fraction_Image");
            Label fractionName = elem.Q<Label>("Fraction_Name");
            Label fractionScore = elem.Q<Label>("Fraction_Score");
            VisualElement oddImage = elem.Q("Odd_Image");
            Label reward = elem.Q<Label>("Reward");

            Fraction currentFraction = fractionsList[i];

            fractionImage.style.backgroundImage = 
            new StyleBackground(Resources.Load<Sprite>(currentFraction.fractionImgPath));
            fractionName.text = currentFraction.name;
            fractionScore.text = currentFraction.score;
            oddImage.style.backgroundImage = new StyleBackground(currentFraction.oddImage);
            reward.text = currentFraction.reward;

            elem.RegisterCallback <ClickEvent, Fraction>(OnClickItem, currentFraction);
        };

        
    }

    void OnClickItem(ClickEvent e, Fraction currentFraction)
    {
        Debug.Log(currentFraction.fractionName);
    }
}
