using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class VirtualCameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCameraBase camera1;
    public CinemachineVirtualCameraBase camera2;

    private void Start()
    {
        // Set the first virtual camera as the active camera
        camera1.Priority = 10;
        camera2.Priority = 0;
    }

    public void OnClick()
    {
        // Find the current active camera
        CinemachineVirtualCameraBase activeCamera = null;
        if (camera1.Priority == 10)
        {
            activeCamera = camera1;
        }
        else if (camera2.Priority == 10)
        {
            activeCamera = camera2;
        }

        // Switch to the other camera
        if (activeCamera == camera1)
        {
            camera1.Priority = 0;
            camera2.Priority = 10;
        }
        else if (activeCamera == camera2)
        {
            camera2.Priority = 0;
            camera1.Priority = 10;
        }
    }
}
