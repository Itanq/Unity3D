using UnityEngine;
using System.Collections;

[System.Serializable]
public class ParticleHelper{

    public ParticleSystem particle;
    public Light light;

    public bool varyAlpha;
    public float minAlpha, maxAlpha;
    public float alphaIncreaseRate, alphaDecreaseRate;
    public float alphaVariation;

    public void IncreaseAlpha()
    {
        if(particle.startColor.a < maxAlpha)
        {
            Color adjustedColor = particle.startColor;
            adjustedColor.a += alphaIncreaseRate * Time.deltaTime;
            adjustedColor.a += Random.Range(0.0f, alphaVariation);
            particle.startColor = adjustedColor;
        }
    }

    public void DecreaseAlpha()
    {
        if(particle.startColor.a>minAlpha)
        {
            Color adjustedColor = particle.startColor;
            adjustedColor.a -= alphaDecreaseRate * Time.deltaTime;
            particle.startColor = adjustedColor;
        }
    }

    public bool varyLight;
    public float minLight, maxLight;
    public float lightIncreaseRate, lightDecreaseRate;
    public float lightVariation;

    public void IncreaseLight()
    {
        if(light.intensity < maxLight)
            light.intensity += lightIncreaseRate * Time.deltaTime;
    }

    public void DecreaseLight()
    {
        if(light.intensity > minLight)
            light.intensity -= lightDecreaseRate * Time.deltaTime;
    }
}
