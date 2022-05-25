using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIpause : MonoBehaviour
{
    [SerializeField] private Toggle volume;
    [SerializeField] private Toggle sound;

    [SerializeField] private GameObject resolutionDropDown;

    // Start is called before the first frame update
    void Start()
    {
        volume.onValueChanged.AddListener(OnVolumeToggleValueChangeHandler);
        sound.onValueChanged.AddListener(OnSoundToggleValueChangeHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
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
