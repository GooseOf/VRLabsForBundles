using UnityEngine;

public class Lapka : MonoBehaviour
{
    [SerializeField] private GrabInteractableWithoutParentChanging interactable;
    [SerializeField] private FollowHandByAxis handFollower;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.selectEntered.AddListener(handFollower.SelectEnter);
            interactable.selectEntered.AddListener(handFollower.SelectEnter);
        }        
    }
}
