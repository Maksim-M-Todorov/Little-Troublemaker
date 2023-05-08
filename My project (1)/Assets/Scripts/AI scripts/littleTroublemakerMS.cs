using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class littleTroublemakerMS : MonoBehaviour
{
    public MoneyCounter canInteractWO;
    public NavMeshAgent navMeshAgent;

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;
    private IInteractable _interactable;

    private Vector3 pos;
    private int ObjGoTo = 0;

    private bool Failsafe = false;
    protected float failsafetimer;
    private int failsafeDelay = 5;

    private void Start()
    {
        ObjID();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ObjGoTo);
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        switch (ObjGoTo)
        {
            case 1:
                {
                    if (canInteractWO.stateWashingMash == false)
                    {
                        pos = GameObject.Find("Washing Mashine").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                    else
                    {
                        ObjID();
                        navMeshAgent.SetDestination(pos);

                    }
                }
                break;

            case 2:
                {
                    if (canInteractWO.stateDryer == false)
                    {
                        pos = GameObject.Find("Dryer").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                    else
                    {
                        ObjID();
                        navMeshAgent.SetDestination(pos);

                    }
                }
                break;

            /*case 3:
                {
                    if (canInteractWO.stateBob == false)
                    {
                        pos = GameObject.Find("Dryer").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                }
                break;*/

            case 3:
                {
                    if (canInteractWO.stateFridge == false)
                    {
                        pos = GameObject.Find("Fridge").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                    else
                    {
                        ObjID();
                        navMeshAgent.SetDestination(pos);

                    }
                }
                break;

            /*case 5:
                {
                    if (canInteractWO.stateTV == false)
                    {
                        pos = GameObject.Find("Dryer").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                }
                break;*/

            case 4:
                {
                    if (canInteractWO.stateRadio == false)
                    {
                        pos = GameObject.Find("Radio").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                    else
                    {
                        ObjID();
                        navMeshAgent.SetDestination(pos);

                    }
                }
                break;

            case 5:
                {
                    if (canInteractWO.stateLamp == false)
                    {
                        pos = GameObject.Find("Lamp").transform.position;
                        navMeshAgent.SetDestination(pos);
                        if (DistanceCheck() == true) transform.LookAt(pos);

                        if (_numFound > 0)
                        {
                            _interactable = _colliders[0].GetComponent<IInteractable>();
                            _interactable.InteractAI(this);
                            ObjID();
                        }
                        else
                        {
                            if (_interactable != null) _interactable = null;
                        }
                    }
                    else
                    {
                        ObjID();
                        navMeshAgent.SetDestination(pos);

                    }
                }
                break;
        }
        if (DistanceCheck() == true)
        {
            ObjID();
        }

        if (Failsafe == true)
        {
            failsafetimer += Time.deltaTime;

            if (failsafetimer >= failsafeDelay)
            {
                failsafetimer = 0f;
                ObjID();
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    private bool DistanceCheck()
    {
        if (Vector3.Distance(transform.position, navMeshAgent.destination) <= 0.3f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   private int ObjID()
    {
        ObjGoTo = Random.Range(1, 6);
        return ObjGoTo;
    }
}
