using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolme;
    [SerializeField] private PostProcessVolume _postProcessVolume2;
    private DepthOfField _depthOfField;
    private ChromaticAberration _chromaticAberration;
    private Vignette _Vignette;
    private Bloom _Bloom;
    private bool isActive = false;
    private bool isAcitve2 = false;

    public float myVignette = 0;
    public float myBloom = 0;


    private void Update()
    {

        _Vignette.intensity.value = myVignette;
        _Bloom.intensity.value = myBloom;

    }

    private void Start()
    {
        _postProcessVolme.profile.TryGetSettings(out _depthOfField);
        _postProcessVolume2.profile.TryGetSettings(out _chromaticAberration);
        _postProcessVolme.profile.TryGetSettings(out _Vignette);
        _postProcessVolme.profile.TryGetSettings(out _Bloom);

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
            //  DOTween.To(() => myFloat, x => myFloat = x, 3.12f, 1);
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

    public void CombatSeeting()
    {
        _Vignette.active = true;
        _Bloom.active = true;
        DOTween.To(() => myVignette, x => myVignette = x, 0.34f, 3);
        DOTween.To(() => myBloom, x => myBloom = x, 15f, 3);
    }
    public void CombatEndSeeting()
    {
        DOTween.To(() => myVignette, x => myVignette = x, 0f, 3);
        DOTween.To(() => myBloom, x => myBloom = x, 0f, 3);


    }
}
