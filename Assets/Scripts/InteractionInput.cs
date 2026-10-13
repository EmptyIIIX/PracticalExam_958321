using UnityEngine;
using UnityEngine.InputSystem;


namespace Theerapat_Boongrom.Code672110100
{
    public class InteractionInput : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private string _actionMapName;
        [SerializeField] private string _interactActionName = "Interact";
        [SerializeField] private ActorTriggerHandler _actorTriggerHandler;
        [SerializeField] private GameObject _actor;
 
        private InputAction _interactAction;
 
        public void SetActionMap(string actionMapName)
        {
            Unsubscribe();
            _interactAction = null;
            _actionMapName = actionMapName;
 
            if (isActiveAndEnabled)
            {
                BindActions();
                Subscribe();
            }
        }
 
        private void Awake()
        {
            if (_playerInput == null)
            {
                _playerInput = GetComponent<PlayerInput>();
            }
 
            if (_actor == null)
            {
                _actor = gameObject;
            }
 
            if (_actorTriggerHandler == null)
            {
                _actorTriggerHandler = GetComponentInChildren<ActorTriggerHandler>();
            }
        }
 
        private void OnEnable()
        {
            BindActions();
            Subscribe();
        }
 
        private void OnDisable()
        {
            Unsubscribe();
        }
 
        private void BindActions()
        {
            // Prefer the asset the player actually uses (PlayerInput.actions),
            // fall back to the project-wide asset.
            InputActionAsset actions = _playerInput != null && _playerInput.actions != null
                ? _playerInput.actions
                : InputSystem.actions;
            if (actions == null)
            {
                Debug.LogError("[InteractionInput] No InputActionAsset found (PlayerInput.actions and InputSystem.actions are both null).");
                return;
            }
 
            string mapName = ResolveActionMapName();
            if (string.IsNullOrEmpty(mapName))
            {
                Debug.LogError("[InteractionInput] Action map name is empty. Set _actionMapName or PlayerInput.defaultActionMap.");
                return;
            }
 
            InputActionMap map = actions.FindActionMap(mapName);
            if (map == null)
            {
                Debug.LogError($"[InteractionInput] Action map '{mapName}' not found.");
                return;
            }
 
            if (!map.enabled)
            {
                map.Enable();
            }
 
            _interactAction = map.FindAction(_interactActionName);
            if (_interactAction == null)
            {
                Debug.LogError($"[InteractionInput] Action '{_interactActionName}' not found in '{mapName}'. " +
                               "Add a Button action Interact (Player 1: <Keyboard>/e, Player 2: <Keyboard>/numpad6).");
            }
        }
 
        /// <summary>
        /// Same priority as InputBinder: serialized map name first, then PlayerInput.defaultActionMap.
        /// </summary>
        private string ResolveActionMapName()
        {
            if (!string.IsNullOrEmpty(_actionMapName))
            {
                return _actionMapName;
            }
 
            if (_playerInput != null && !string.IsNullOrEmpty(_playerInput.defaultActionMap))
            {
                return _playerInput.defaultActionMap;
            }
 
            return _actionMapName;
        }
 
        private void Subscribe()
        {
            if (_interactAction != null)
            {
                _interactAction.performed += OnInteractPerformed;
            }
        }
 
        private void Unsubscribe()
        {
            if (_interactAction != null)
            {
                _interactAction.performed -= OnInteractPerformed;
            }
        }
 
        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            if (_actorTriggerHandler == null)
            {
                _actorTriggerHandler = GetComponentInChildren<ActorTriggerHandler>();
            }
 
            IInteractable interactable = _actorTriggerHandler != null
                ? _actorTriggerHandler.GetInteractable()
                : null;
 
            if (interactable == null)
            {
                return;
            }
 
            GameObject actor = _actor != null ? _actor : gameObject;
            interactable.Interact(actor);
        }
    }
    
}
