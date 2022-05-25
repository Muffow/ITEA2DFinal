using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    [SerializeField] private bool isGamePaused = true;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject point;
    [SerializeField] private Toggle volume;
    [SerializeField] private Button _playButton;




    // Start is called before the first frame update
    void Start()
    {
        volume.onValueChanged.AddListener(OnVolumeToggleValueChangeHandler);
        _playButton.onClick.AddListener(OnPlayButtonClickHandler);

    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        //почему со второго нажатия только открывается пауза?
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isGamePaused)
            {
                isGamePaused = true;
                Time.timeScale = 0;
                settingsMenu.SetActive(true);
            }
            else
            {
                isGamePaused = false;
                settingsMenu.SetActive(false);
                Time.timeScale = 1;
            }
            

        }

    }
    private void OnVolumeToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnVolumeToggleValueChange] OK, isOn: {isOn}");
    }

    private void OnPlayButtonClickHandler()
    {
        Debug.Log("[OnPlayButtonClickHandler] OK");
        settingsMenu.SetActive(false);
    }
}

