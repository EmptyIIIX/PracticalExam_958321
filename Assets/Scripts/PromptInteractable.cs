using UnityEngine;

namespace Theerapat_Boongrom.Code672110100
{
    public class PromptInteractable : GenericInteractable
    {
        public override void ActorEnter(GameObject actor)
        {
            base.ActorEnter(actor);
            InteractPrompt.Show(this);
        }
 
        public override void ActorExit(GameObject actor)
        {
            base.ActorExit(actor);
            InteractPrompt.Hide(this);
        }
 
        // Covers Destroy() on interact, where OnTriggerExit may never fire.
        private void OnDestroy()
        {
            InteractPrompt.Hide(this);
        }

        public override void Interact(GameObject actor)
        {
            Debug.Log("Interact called");
            base.Interact(actor);
        }
    }
    
}
