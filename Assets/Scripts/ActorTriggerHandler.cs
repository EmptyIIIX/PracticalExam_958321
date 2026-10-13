using UnityEngine;
using System.Collections.Generic;

namespace Theerapat_Boongrom.Code672110100
{
    public class ActorTriggerHandler : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> m_TriggeredGameObjects = new();
        [SerializeField] protected GameObject m_Actor;
 
        protected virtual void Start()
        {
            if (m_Actor == null)
            {
                Transform parent = transform.parent;
                m_Actor = parent != null ? parent.gameObject : gameObject;
            }
        }
 
        protected virtual void OnTriggerEnter(Collider other)
        {
            IInteractable[] interactableComponents = other.GetComponents<IInteractable>();
            if (interactableComponents == null || interactableComponents.Length == 0)
            {
                return;
            }
 
            foreach (IInteractable interactable in interactableComponents)
            {
                if (interactable is IActorEnterExitHandler enterExitHandler)
                {
                    enterExitHandler.ActorEnter(m_Actor);
                }
            }
 
            m_TriggeredGameObjects.Add(other.gameObject);
        }
 
        protected virtual void OnTriggerExit(Collider other)
        {
            IInteractable[] interactableComponents = other.GetComponents<IInteractable>();
            if (interactableComponents == null || interactableComponents.Length == 0)
            {
                return;
            }
 
            foreach (IInteractable interactable in interactableComponents)
            {
                if (interactable is IActorEnterExitHandler enterExitHandler)
                {
                    enterExitHandler.ActorExit(m_Actor);
                }
            }
 
            m_TriggeredGameObjects.Remove(other.gameObject);
        }
 
        public virtual IInteractable GetInteractable()
        {
            m_TriggeredGameObjects.RemoveAll(triggered => triggered == null);
 
            if (m_TriggeredGameObjects.Count == 0)
            {
                return null;
            }
 
            return m_TriggeredGameObjects[0].GetComponent<IInteractable>();
        }
    }
    
}
