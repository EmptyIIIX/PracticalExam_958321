using UnityEngine;
using UnityEngine.Events;

namespace Theerapat_Boongrom.Code672110100
{
    public class GenericInteractable : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] protected UnityEvent m_OnInteract = new();
        [SerializeField] protected UnityEvent m_OnActorEnter = new();
        [SerializeField] protected UnityEvent m_OnActorExit = new();

        [SerializeField] protected UnityEvent <GameObject > m_OnInteractGameObject = new();
        [SerializeField] protected UnityEvent <GameObject > m_OnActorEnterGameObject = new();
        [SerializeField] protected UnityEvent <GameObject > m_OnActorExitGameObject = new();

        public virtual void Interact(GameObject actor)
        {
            m_OnInteract.Invoke();
            m_OnInteractGameObject.Invoke(actor);
        }

        public virtual void ActorEnter(GameObject actor)
        {
            m_OnActorEnter.Invoke();
            m_OnActorEnterGameObject.Invoke(actor);
        }

        public virtual void ActorExit(GameObject actor)
        {
            m_OnActorExit.Invoke();
            m_OnActorExitGameObject.Invoke(actor);
        }
    }
    
}
