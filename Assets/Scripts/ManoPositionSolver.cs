using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARDK.Extensions;
using Niantic.ARDK.AR.Awareness;

public class ManoPositionSolver : MonoBehaviour
{
    [SerializeField] private ARHandTrackingManager handTrackingManager;
    [SerializeField] private Camera aRCamera;
    [SerializeField] private float minHandConfidence = 0.85f;

    private Vector3 handPostion;
    private bool flag;

    public Vector3 HandPosition { get => handPostion; }
    public bool Flag { get => flag; }

    // Start is called before the first frame update
    void Start()
    {
        handTrackingManager.HandTrackingUpdated += HandTrackingUpdate;
    }

    private void OnDestroy()
    {
        handTrackingManager.HandTrackingUpdated -= HandTrackingUpdate;
    }

    private void HandTrackingUpdate(HumanTrackingArgs handData)
    {
        var detections = handData.TrackingData?.AlignedDetections;
        if (detections == null)
        {
            flag = true;
            return;
        }
        else
        {
            flag = false;
        }

        foreach (var detection in detections)
        {
            if (detection.Confidence < minHandConfidence)
            {
                return;
            }

            Vector3 detectionSize = new Vector3(detection.Rect.width, detection.Rect.height, 0);
            float depthEstimation = 0.2f + Mathf.Abs(1 - detectionSize.magnitude);

            handPostion = aRCamera.ViewportToWorldPoint(new Vector3(detection.Rect.center.x, 1 - detection.Rect.center.y, depthEstimation));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
