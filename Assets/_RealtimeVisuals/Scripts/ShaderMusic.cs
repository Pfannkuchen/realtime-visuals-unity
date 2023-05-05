
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShaderMusic : MonoBehaviour
{
    private AudioSource _source;
    private AudioSource Source => _source ??= GetComponent<AudioSource>();

    [SerializeField] private AudioClip _song;
    [SerializeField] private float _bandUpdateRate = 10f;
    [SerializeField] private float _volumeBoost = 1f;

    [SerializeField] private List<Renderer> _affectedRenderers;
    private List<Renderer> AffectedRenderers => _affectedRenderers ??= new List<Renderer>();
    
    [SerializeField] private string _shaderProperty = "_MusicValues";

    private float[] _samples = new float[512];
    private float[] _freqBands = new float[4];

    private void Start()
    {
        if (Source != null)
        {
            Source.clip = _song;
            Source.Play();
        }
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        ApplyToRenderers();
    }
    
    private void GetSpectrumAudioSource()
    {
        Source.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    
    private void MakeFrequencyBands()
    {
        int count = 0;
        
        for(int i = 0; i < _freqBands.Length; i++)
        {
            float average = 0;
            int sampleCount = (int) Math.Pow(2, i) * 2;
            
            if(i == 7) sampleCount += 2;
            
            for(int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            
            average /= count;
            
            // map to 0-1
            average = average * 5f * _volumeBoost;
            average = Mathf.Clamp(average, 0f, 1f);
            _freqBands[i] = Mathf.Lerp(_freqBands[i], average, _bandUpdateRate * Time.deltaTime);
        }
    }
    
    private void ApplyToRenderers()
    {
        foreach(Renderer r in AffectedRenderers)
        {
            if(r == null) continue;
            
            r.material.SetVector(_shaderProperty, GetBands());
        }
    }
    
    public Vector4 GetBands()
    {
        return new Vector4(_freqBands[0], _freqBands[1], _freqBands[2], _freqBands[3]);
    }
    
    public float GetBand(int in_band)
    {
        if(in_band < 0 || in_band > 7) return 0;
        
        return _freqBands[in_band];
    }
    
    public float GetAverageBand()
    {
        float average = 0;
        
        foreach(float f in _freqBands)
        {
            average += f;
        }
        
        return average / _freqBands.Length;
    }
}
