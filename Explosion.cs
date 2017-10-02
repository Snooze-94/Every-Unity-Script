using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem Main;
    public SparkParticles Sparks;
    public ParticleSystem Flash;

    void Awake()
    {
        Main.Play();
        Sparks.Play();
        Flash.Play();
    }
}

