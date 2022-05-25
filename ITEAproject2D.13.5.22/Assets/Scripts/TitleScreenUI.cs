using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _mediumButton;
    [SerializeField] private Button _hardButton;
    [SerializeField] private Button _playButton;

    [SerializeField] private Toggle _volume;
    [SerializeField] private Toggle _sound;

    [SerializeField] private GameObject _resolutionDropDown;


    // Start is called before the first frame update
    void Start()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClickHandler);
        _easyButton.onClick.AddListener(OnEasyButtonClickHandler); 
        _mediumButton.onClick.AddListener(OnMediumButtonClickHandler);
        _hardButton.onClick.AddListener(OnHardButtonClickHandler);
        _playButton.onClick.AddListener(OnPlayButtonClickHandler);

        _volume.onValueChanged.AddListener(OnVolumeToggleValueChangeHandler);
        _sound.onValueChanged.AddListener(OnSoundToggleValueChangeHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCloseButtonClickHandler()
    {
        Debug.Log("[OnCloseButtonClickHandler] OK");
        gameObject.SetActive(false);
    }
    private void OnEasyButtonClickHandler()
    {
        Debug.Log("[OnEasyButtonClickHandler] OK");
    }
    private void OnMediumButtonClickHandler()
    {
        Debug.Log("[OnMediumButtonClickHandler] OK");
    }
    private void OnHardButtonClickHandler()
    {
        Debug.Log("[OnHardButtonClickHandler] OK");
    }
    private void OnPlayButtonClickHandler()
    {
        Debug.Log("[OnPlayButtonClickHandler] OK");
        gameObject.SetActive(false);
    }

    
    private void OnSoundToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnSoundToggleValueChange] OK, isOn: {isOn}");
    }
    private void OnVolumeToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnVolumeToggleValueChange] OK, isOn: {isOn}");
    }
}
