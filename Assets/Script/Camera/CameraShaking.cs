using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaking : MonoBehaviour
{
    public static CameraShaking Instance {get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float shakerTimer;
    private float shakerTimeTotal;
    private float startingIntensity;
    private void Awake() {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakerTimer > 0) {
            shakerTimer -= Time.deltaTime;
            if (shakerTimer <= 0) {
                StopSkaking();
            }
        }
    }

    public void ShakeCamera(float intensity, float time) {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakerTimer = time;
        startingIntensity = intensity;
    }

    public void StopSkaking() {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1f - (shakerTimer / shakerTimeTotal));
    }
}
