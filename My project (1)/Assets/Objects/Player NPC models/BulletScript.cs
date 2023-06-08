using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3f;

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    public int _numFound;
    private IInteractable _interactable;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();
            _interactable.InteractBullet(this);
        }
        else
        {
            if (_interactable != null) _interactable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
