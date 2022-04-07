using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolme;
    private DepthOfField _depthOfField;
    private bool isActive = false;


    private void Start()
    {
        _postProcessVolme.profile.TryGetSettings(out _depthOfField);
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
}
