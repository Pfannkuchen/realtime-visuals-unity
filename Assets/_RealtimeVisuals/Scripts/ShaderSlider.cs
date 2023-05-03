using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderSlider : MonoBehaviour
{
    private Slider _localSlider;
    private Slider LocalSlider => _localSlider ??= GetComponent<Slider>();

    [SerializeField] private List<Renderer> _affectedRenderers;
    private List<Renderer> AffectedRenderers => _affectedRenderers ??= new List<Renderer>();
    
    [SerializeField] private string _shaderProperty = "_SliderValue";
    
    // start listening to slider changes and call private function
    private void OnEnable()
    {
        if(LocalSlider != null) LocalSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    
    // stop listening to slider changes
    private void OnDisable()
    {
        if(LocalSlider != null) LocalSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
    
    // this is the function that will be called when the slider changes
    private void OnSliderValueChanged(float value)
    {
        foreach(Renderer r in AffectedRenderers)
        {
            if(r == null) continue;
            
            r.material.SetFloat(_shaderProperty, value);
        }
    }
}
