using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolme;
    [SerializeField] private PostProcessVolume _postProcessVolume2;
    private DepthOfField _depthOfField;
    private ChromaticAberration _chromaticAberration;
    private bool isActive = false;
    private bool isAcitve2 = false;


    private void Start()
    {
        _postProcessVolme.profile.TryGetSettings(out _depthOfField);
        _postProcessVolume2.profile.TryGetSettings(out _chromaticAberration);
    }

    public void DepthOfFieldOnOff(bool value)
    {
        _depthOfField.active = value;
        if (isActive)
        {
            isActive = false;
            _depthOfField.active = false;
        }
        else
        {
            isActive = true;
            _depthOfField.active = true;
        }

    }

    public void ChromaticAberration_On_Off(bool value)
    {
        _chromaticAberration.active = value;
        if (isAcitve2)
        {
            isAcitve2 = false;
            _chromaticAberration.active = false;
        }
        else
        {
            isAcitve2 = true;
            _chromaticAberration.active = true;
        }
    }
}
