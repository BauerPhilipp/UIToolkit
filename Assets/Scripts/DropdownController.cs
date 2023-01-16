using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DropdownController 
{
    VisualElement root;
    Fraction currentFraction = null;

    public DropdownController(VisualElement root, List<Fraction> fractions)
    {

        this.root = root;
        VisualElement container = root.Q("DropdownContainer");

        PopupField<Fraction> popupField = new PopupField<Fraction>();
        popupField.choices = fractions;

        popupField.value = fractions[0];
        currentFraction = fractions[0];

        popupField.formatListItemCallback = elem => elem.fractionName;
        popupField.formatSelectedValueCallback = elem => elem.fractionName;

        popupField.RegisterCallback<ChangeEvent<Fraction>>(OnFractionChange);

        container.Add(popupField);
        UpdateUI();

    }

    void OnFractionChange(ChangeEvent<Fraction> evt)
    {
        
        currentFraction = evt.newValue;
        UpdateUI();
    }

    void UpdateUI() 
    {
        VisualElement character = root.Q("Character");
        VisualElement panelFraction = root.Q("PanelFraction");
        Label labelMotto = root.Q<Label>("LabelMotto");


        character.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(currentFraction.characterImgPath));
        panelFraction.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(currentFraction.fractionImgPath));
        labelMotto.text = currentFraction.fractionMotto;


    }

}
