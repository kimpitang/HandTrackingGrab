using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameplayHand : BaseHand
{
    // The interactor we react to
    public Pose grabpose;

    private void OnEnable()
    {
        GameObject parent = transform.parent.gameObject;
        if (handType == HandType.Left)
        {
            grabpose = parent.GetComponent<GrabLeft>().m_grabbedObj.GetComponent<PoseContainer>().pose;
        }
        else if (handType == HandType.Right)
        {
            grabpose = parent.GetComponent<GrabRight>().m_grabbedObj.GetComponent<PoseContainer>().pose;
        }
        ApplyPose(grabpose);
    }

    private void OnDisable()
    {
        // Unsubscribe to selected events
    }

    private void TryApplyObjectPose(XRBaseInteractable interactable)
    {
        //
    }

    private void TryApplyDefaultPose(XRBaseInteractable interactable)
    {
        // Try and get pose container, and apply
    }

    public override void ApplyOffset(Vector3 position, Quaternion rotation)
    {
        transform.localPosition = position;
        transform.localRotation = rotation;
    }

    private void OnValidate()
    {
        // Let's have this done automatically, but not hide the requirement
    }
}