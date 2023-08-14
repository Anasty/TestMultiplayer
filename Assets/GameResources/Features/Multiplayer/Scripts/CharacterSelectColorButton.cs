using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectColorButton : AbstractButtonView
{
    [SerializeField]
    private int colorId;
    [SerializeField]
    private Image image;
    [SerializeField]
    private GameObject selectedGameObject;

    public override void OnButtonClick()
    {
        GameMultiplayer.Instance.ChangePlayerColor(colorId);
    }

    private void Start()
    {
        GameMultiplayer.Instance.onPlayerDataNetworkListChanged += UpdateIsSelected;
        image.color = GameMultiplayer.Instance.GetPlayerColor(colorId);
        UpdateIsSelected();
    }


    private void UpdateIsSelected()
    {
        selectedGameObject.SetActive(GameMultiplayer.Instance.GetPlayerData().colorId == colorId);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameMultiplayer.Instance.onPlayerDataNetworkListChanged -= UpdateIsSelected;
    }
}
