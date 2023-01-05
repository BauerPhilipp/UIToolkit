using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BadgeScript : MonoBehaviour
{
    List<Label> labels = new List<Label>();

    VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        InitializeBadges();
    }

    void InitializeBadges()
    {

        string[] romanNum = { "I", "II", "III", "IV", "V", "VI"};

        int index = 0;

        root.Query<VisualElement>("PanelBadges")
            .Descendents<VisualElement>("LabelLevel")
            .ForEach(elem => (elem as Label).text = romanNum[index++]);
    }

}
