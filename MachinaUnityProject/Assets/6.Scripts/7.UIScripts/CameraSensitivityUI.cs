using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraSensitivityUI : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;

    [Header("UI Sliders")]
    [SerializeField] private Slider xSensitivitySlider;
    [SerializeField] private Slider ySensitivitySlider;

    [Header("Speed Ranges")]
    [SerializeField] private float minXSpeed = 0f;
    [SerializeField] private float maxXSpeed = 500f;
    [SerializeField] private float minYSpeed = 0f;
    [SerializeField] private float maxYSpeed = 10f;

    private bool isCameraRotating = true;

    private void Start()
    {
        // Inicializa los sliders con los valores actuales de la cámara
        if (freeLookCamera != null)
        {
            xSensitivitySlider.minValue = minXSpeed;
            xSensitivitySlider.maxValue = maxXSpeed;
            xSensitivitySlider.value = freeLookCamera.m_XAxis.m_MaxSpeed;

            ySensitivitySlider.minValue = minYSpeed;
            ySensitivitySlider.maxValue = maxYSpeed;
            ySensitivitySlider.value = freeLookCamera.m_YAxis.m_MaxSpeed;
        }

        // Asigna listeners
        xSensitivitySlider.onValueChanged.AddListener(UpdateXSensitivity);
        ySensitivitySlider.onValueChanged.AddListener(UpdateYSensitivity);
    }

    public void UpdateXSensitivity(float value)
    {
        if (freeLookCamera != null)
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = value;
        }
    }

    public void UpdateYSensitivity(float value)
    {
        if (freeLookCamera != null)
        {
            freeLookCamera.m_YAxis.m_MaxSpeed = value;
        }
    }

    public void AlternCameraRotation()
    {
        isCameraRotating |= !isCameraRotating;

        if (isCameraRotating)
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 220f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 1.5f;
        }
        else
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0f;
        } 
    }
}
