using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    public GameObject combo;
    public TextMeshProUGUI comboText;
    public void ShowCombo(bool show)
    {
        combo.SetActive(show);
    }

    public void UpdateCombo(int multiplier)
    {
        comboText.text = multiplier.ToString() + "!";
    }
}
