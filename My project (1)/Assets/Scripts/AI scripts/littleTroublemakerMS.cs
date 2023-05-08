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

    //Roll the dice at the start to decide first appliance and go to it.
    private void Start()
    {
        ObjID();
    }

    //Custom Function used to get the loc of the appliance and pass in the cordinates to the AI to go to.
    private void GoToAppliance(bool app_state, string lookfor_app)
    {
        if (app_state == false)
        {
            pos = GameObject.Find(lookfor_app).transform.position;
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

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ObjGoTo);
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        //To which object can the AI go based on a dice roll.
        switch (ObjGoTo)
        {
            case 1:
                {
                    GoToAppliance(canInteractWO.stateWashingMash, "Washing Mashine");
                }
                break;

            case 2:
                {
                    GoToAppliance(canInteractWO.stateDryer, "Dryer");
                }
                break;

            /*case 3:
                {
                    GoToAppliance(canInteractWO.stateBob, "Bob");
                }
                break;*/

            case 3:
                {
                    GoToAppliance(canInteractWO.stateFridge, "Fridge");
                }
                break;

            /*case 5:
                {
                    GoToAppliance(canInteractWO.stateTV, "TV");
                }
                break;*/

            case 4:
                {
                    GoToAppliance(canInteractWO.stateRadio, "Radio");
                }
                break;

            case 5:
                {
                    GoToAppliance(canInteractWO.stateLamp, "Lamp");
                }
                break;
        }
        if (DistanceCheck() == true)
        {
            ObjID();
        }

        //If the AI losses the cords to where it needs to go, after 5 seconds try and pass in new cords.
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
    //Gizmo sphere that shows the interactable hitbox of the AI.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    //Distance check to the passed in cords of the Appliance to the AI.
    //!!! The cord are the origin point of the object. If the object is wide account for that by adding to the distance in Update.
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

    //Function to roll a dice and decide to which object to go.
   private int ObjID()
    {
        ObjGoTo = Random.Range(1, 6);
        return ObjGoTo;
    }
}
