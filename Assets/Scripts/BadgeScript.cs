using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BadgeScript : MonoBehaviour
{
    VisualElement root;

    [SerializeField] List<Fraction> fractions;
       
    private void OnEnable()
    {
        Application.targetFrameRate = 60;

        root = GetComponent<UIDocument>().rootVisualElement;

        DropdownController controller = new DropdownController(root, fractions);
        ListManager listManager = new ListManager(root, fractions);

        InitializeBadges();
    }

    void InitializeBadges()
    {
        List<Label> labels = new List<Label>();
        string[] romanNum = { "I", "II", "III", "IV", "V", "VI"};

        int index = 0;

        root.Query<VisualElement>("PanelBadges")
            .Descendents<VisualElement>("LabelLevel")
            .ForEach(elem => (elem as Label).text = romanNum[index++]);
    }

}
