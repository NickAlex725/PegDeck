using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private RectTransform infoPanel;
    [SerializeField] private RectTransform infoButton;

    [Header("Settings")]
    public bool panelOpen = false;
    [SerializeField] private float lerpSpeed = 10f;

    [Header("Positions")]
    [SerializeField] private Vector2 openPos = Vector2.zero;
    [SerializeField] private Vector2 closePos = new Vector2(0, -360);
    [SerializeField] private Vector2 buttonClosePos = Vector2.zero;

    [Header("Info")]
    [SerializeField] private GameObject peggleInfo;
    [SerializeField] private GameObject playerInfo;
    [SerializeField] private GameObject enemyInfo;

    private void Awake()
    {
        
    }
    private void Update()
    {
        #region Lerp Stuff
        if (infoPanel != null && infoButton != null)
        {
            if(panelOpen)
            {
                //open lerp
                if(infoPanel.anchoredPosition != openPos)
                {
                    if(Vector2.Distance(infoPanel.anchoredPosition, openPos) > 2.0f)
                    {
                        infoPanel.anchoredPosition = Vector2.Lerp(infoPanel.anchoredPosition, openPos, lerpSpeed * Time.deltaTime);
                    }
                    else
                    {
                        infoPanel.anchoredPosition = openPos;
                    }
                }
                if(infoButton.anchoredPosition != closePos)
                {
                    if(Vector2.Distance(infoButton.anchoredPosition, closePos) > 2.0f)
                    {
                        infoButton.anchoredPosition = Vector2.Lerp(infoButton.anchoredPosition, closePos, lerpSpeed * Time.deltaTime);
                    }
                    else
                    {
                        infoButton.anchoredPosition = closePos;
                    }
                }
            }
            else
            {
                //closed lerp
                if (infoPanel.anchoredPosition != closePos)
                {
                    if (Vector2.Distance(infoPanel.anchoredPosition, closePos) > 2.0f)
                    {
                        infoPanel.anchoredPosition = Vector2.Lerp(infoPanel.anchoredPosition, closePos, lerpSpeed * Time.deltaTime);
                    }
                    else
                    {
                        infoPanel.anchoredPosition = closePos;
                    }
                }
                if (infoButton.anchoredPosition != buttonClosePos)
                {
                    if (Vector2.Distance(infoButton.anchoredPosition, buttonClosePos) > 2.0f)
                    {
                        infoButton.anchoredPosition = Vector2.Lerp(infoButton.anchoredPosition, buttonClosePos, lerpSpeed * Time.deltaTime);
                    }
                    else
                    {
                        infoButton.anchoredPosition = buttonClosePos;
                    }
                }
            }
        }
        #endregion
    }

    public void UpdatePanel(InfoState state)
    {
        switch (state)
        {
            case InfoState.PeggleText:
                //
                if (peggleInfo != null) peggleInfo.SetActive(false);
                if (playerInfo != null) playerInfo.SetActive(false);
                if (enemyInfo != null) enemyInfo.SetActive(false);
                break;
            case InfoState.PlayerText:
                //
                if (peggleInfo != null) peggleInfo.SetActive(false);
                if (playerInfo != null) playerInfo.SetActive(false);
                if (enemyInfo != null) enemyInfo.SetActive(false);
                break;
            case InfoState.EnemyText:
                //
                if (peggleInfo != null) peggleInfo.SetActive(false);
                if (playerInfo != null) playerInfo.SetActive(false);
                if (enemyInfo != null) enemyInfo.SetActive(false);
                break;
        }
    }
    public void TogglePanel()
    {
        panelOpen = !panelOpen;
    }
}

public enum InfoState { PeggleText, PlayerText, EnemyText}
