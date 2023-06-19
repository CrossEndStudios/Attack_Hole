using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public Color normalColor;
    public Color highlightColor;
    public Character character;
    public ShopManager shop;
    private Button button;
    public Sprite Selected;
    public Sprite NotSelected;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }
    // Initializes the button with the given character and shop
    public void InitButton(Character character, ShopManager shop)
    {
        this.character = character;
        this.shop = shop;

        iconImage.sprite = character.icon;
        nameText.text = character.name;

        costText.text = character.unlockCost.ToString();

        UpdateButtonState();
    }

    public void UpdateButtonState()
    {
        if (character.isUnlocked)
        {
          //  costText.gameObject.SetActive(false);
            costText.text = "Unlocked";
            iconImage.color = new Color(1f, 1f, 1f, 1f);

            button.interactable = true;
        }
        else
        {
            costText.gameObject.SetActive(true);
            button.interactable = shop.coins >= character.unlockCost;
           // GetComponent<Image>().color= Color.grey;
           iconImage.color = new Color(0f, 0f, 0f, 0.5f);
        }
    }
    public void HandleClick()
    {
        shop.SelectCharacter(character);
    }

    public void SetHighlight(bool highlighted)
    {
        Image image = GetComponent<Image>();
        image.sprite = highlighted ? Selected : NotSelected;
    }

    
}