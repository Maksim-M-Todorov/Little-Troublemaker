using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class littleTroublemakerMS : MonoBehaviour
{
    public MoneyCounter canInteractWO;
    public NavMeshAgent navMeshAgent;
    public RoundController roundController;
    public AudioManager audioData;

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    public int _numFound;
    private IInteractable _interactable;

    private Vector3 pos;
    private int ObjGoTo = 0;

    private bool Failsafe = true;
    protected float failsafetimer;
    private int failsafeDelay = 8;

    float delay = 5;
    float countdown;
    bool speaking = false;

    private void Start()
    {
        countdown = delay;
        //Function that gets a random number from a given range
        //This number is the same as the ID of an appliance
        ObjID();

        //Kid growing up
        switch (roundController.roundCount)
        {
            case 0:
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                break;
            
            case 1:
                gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                break;
            
            case 2:
                gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
           
            case 3:
                gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                break;
        }
        if(audioData != null)
        {
            audioData.Stop("kidPanting");
            audioData.Stop("kidGiggle");
            audioData.Stop("kidCry");
        }
    }

    //Custom Function used to get the location/position of the appliance and pass in the cordinates to the AI to go to.
    private void GoToAppliance(bool app_state, string lookfor_app)
    {
        //Check to see if the chosen appliance is turned on
        //If that is the case try to get a new appliance that is off
        if (app_state == false)
        {
            //Get cords
            pos = GameObject.Find(lookfor_app).transform.position;
            //Go to cords
            navMeshAgent.SetDestination(pos);

            //Oriantate the AI to face the object, helpful when the AI has to do tight corner turns
            if (DistanceCheck() == true) transform.LookAt(pos);

            //Interact with object when in range
            if (_numFound > 0)
            {
                _interactable = _colliders[0].GetComponent<IInteractable>();
                _interactable.InteractAI(this);
            }
            else
            {
                if (_interactable != null) _interactable = null;
            }
        }
        //Run last check to see if there is 1 last appliance that is not on
        else
        {
            ObjID();
            navMeshAgent.SetDestination(pos);
            //If all appliances are on go to a predesignated spot
            //This is here to fix an issue where the in case of every appliance being on
            //The AI would camp and constantly interact (turning on) the last appliance it went to
            //Good thing here is that the code is wrapped in such a way that when
            //an appliance DOES get turned off the AI would start moving torwards it again
            if (app_state == true)
            {
                pos = GameObject.Find("RestingPlace").transform.position;
                navMeshAgent.SetDestination(pos);
                ObjID();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (speaking == false)
            {
                countdown -= Time.deltaTime;
                if (countdown <= 0)
                {
                    speaking = true;
                    countdown = delay;
                    int saywhat = Random.Range(0,2);
                    switch (saywhat)
                    {
                        case 0:
                            if (!audioData.isPlaying("kidGiggle") && !audioData.isPlaying("kidCry"))
                            {
                                audioData.Play("kidGiggle");
                                speaking = false;
                            }
                            break;

                        case 1:
                            if (!audioData.isPlaying("kidCry") && !audioData.isPlaying("kidGiggle"))
                            {
                                audioData.Play("kidCry");
                                speaking = false;
                            }
                            break;
                    }
                }
            }
        }
        else
        {
            audioData.Stop("kidGiggle");
            audioData.Stop("kidCry");
        }


        if (!audioData.isPlaying("kidRunning") && Time.timeScale != 0)
        {
            audioData.Play("kidRunning");
        }
    
        if(Time.timeScale == 0 || Vector3.Distance(gameObject.transform.position, GameObject.Find("RestingPlace").transform.position) <=0.3f)
        {
            audioData.Stop("kidRunning");
        }

        if (!audioData.isPlaying("kidRunning") && Time.timeScale != 0 && Vector3.Distance(gameObject.transform.position, GameObject.Find("RestingPlace").transform.position) <= 0.3f)
        {
            if (!audioData.isPlaying("kidPanting"))
            {
                audioData.Play("kidPanting");
            }
        }
        else
        {
            audioData.Stop("kidPanting");
        }

        //Debug.Log(roundController.roundCount);
        //Debug.Log(ObjGoTo);

        //Number of interactables in the collision hitbox sphere
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        //To which object can the AI go based on a dice roll.
        if (GameObject.Find("TeddyBearGrenade(Clone)") != null)
        {
            pos = GameObject.Find("TeddyBearGrenade(Clone)").transform.position;
            navMeshAgent.SetDestination(pos);
            if (audioData != null && gameObject.name == "LittleTroublemaker" && Time.timeScale != 0)
            {
                switch (roundController.roundCount)
                {
                    case 0:
                        if (!audioData.isPlaying("kidYayV1"))
                        {
                            audioData.PlayDelayed("kidYayV1", 2);
                        }
                        break;

                    case 1:
                        if (!audioData.isPlaying("kidYayV1"))
                        {
                            audioData.PlayDelayed("kidYayV1", 2);
                        }
                        break;

                    case 2:
                        if (!audioData.isPlaying("kidYayV2"))
                        {
                            audioData.PlayDelayed("kidYayV2", 2);
                        }
                        break;

                    case 3:
                        if (!audioData.isPlaying("kidYayV3"))
                        {
                            audioData.PlayDelayed("kidYayV3", 2);
                        }
                        break;
                }
            }
        }
        else
        {
            audioData.Stop("kidYayV1");
            audioData.Stop("kidYayV2");
            audioData.Stop("kidYayV3");
            switch (ObjGoTo)
            {

                case -10:
                    {
                        GoToAppliance(canInteractWO.stateLamp, "Lamp");
                    }
                    break;

                case -9:
                    {
                        GoToAppliance(canInteractWO.stateLamp_MasterBedroom, "Lamp Master Bedroom");
                    }
                    break;

                case -8:
                    {
                        GoToAppliance(canInteractWO.stateLight_Entry, "Light Entry");
                    }
                    break;

                case -7:
                    {
                        GoToAppliance(canInteractWO.stateLight_Toilet, "Light Toilet");
                    }
                    break;

                case -6:
                    {
                        GoToAppliance(canInteractWO.stateLight_Livingroom, "Light Livingroom");
                    }
                    break;

                case -5:
                    {
                        GoToAppliance(canInteractWO.stateLight_Diningroom, "Light Hall");
                    }
                    break;

                case -4:
                    {
                        GoToAppliance(canInteractWO.stateLight_Kitchen, "Light Kitchen");
                    }
                    break;

                case -3:
                    {
                        GoToAppliance(canInteractWO.stateLight_Laundryroom, "Light Laundryroom");
                    }
                    break;

                case -2:
                    {
                        GoToAppliance(canInteractWO.stateLight_Bathroom, "Light Bathroom");
                    }
                    break;

                case -1:
                    {
                        GoToAppliance(canInteractWO.stateLight_MasterBedroom, "Light Master Bedroom");
                    }
                    break;

                case 0:
                    {
                        GoToAppliance(canInteractWO.stateLight_Kidsroom, "Light Kidsroom");
                    }
                    break;

                case 1:
                    {
                        GoToAppliance(canInteractWO.stateToyTrain, "Toy Train");
                    }
                    break;

                case 2:
                    {
                        GoToAppliance(canInteractWO.stateBob, "Bob");
                    }
                    break;

                case 3:
                    {
                        GoToAppliance(canInteractWO.stateGamingSystem, "Game Console");
                    }
                    break;

                case 4:
                    {
                        GoToAppliance(canInteractWO.stateVacuum, "Vacuum");
                    }
                    break;

                case 5:
                    {
                        GoToAppliance(canInteractWO.stateCounter_Dishwasher_Kitchen, "Dishwasher");
                    }
                    break;

                case 6:
                    {
                        GoToAppliance(canInteractWO.stateRadio, "Radio");
                    }
                    break;

                case 7:
                    {
                        GoToAppliance(canInteractWO.stateIpad, "Ipad");
                    }
                    break;
                    
                case 8:
                    {
                        GoToAppliance(canInteractWO.stateKettle, "Kettle");
                    }
                    break;
                          
                case 9:
                    {
                        GoToAppliance(canInteractWO.stateFridge, "Fridge");
                    }
                    break;
                    
                case 10:
                    {
                        GoToAppliance(canInteractWO.stateWashingMash, "Washing Mashine");
                    }
                    break;
                    
                case 11:
                    {
                        GoToAppliance(canInteractWO.stateDryer, "Dryer");
                    }
                    break;
                    
                case 12:
                    {
                        GoToAppliance(canInteractWO.stateTV, "TV");
                    }
                    break;
                    
                case 13:
                    {
                        GoToAppliance(canInteractWO.stateBlender, "Blender");
                    }
                    break;
                    
                case 14:
                    {
                        GoToAppliance(canInteractWO.stateStove, "Stove");
                    }
                    break;
                    
                case 15:
                    {
                        GoToAppliance(canInteractWO.stateRadiator_Hall, "Radiator Hall");
                    }
                    break;
                    
                case 16:
                    {
                        GoToAppliance(canInteractWO.stateRadiator_Kidsroom, "Radiator Kids Room");
                    }
                    break;
      
                case 17:
                    {
                        GoToAppliance(canInteractWO.stateRadiator_MasterBedroom, "Radiator Master Bedroom");
                    }
                    break;

                case 18:
                    {
                        GoToAppliance(canInteractWO.stateShower, "Shower");
                    }
                    break;
                    
                case 19:
                    {
                        GoToAppliance(canInteractWO.stateMicrowave, "Microwave");
                    }
                    break;
                          
                case 20:
                    {
                        GoToAppliance(canInteractWO.stateIron, "Iron");
                    }
                    break;
                                   
                case 21:
                    {
                        GoToAppliance(canInteractWO.stateCounter_Sink_Kitchen, "Kitchen Sink");
                    }
                    break;
                                       
                case 22:
                    {
                        GoToAppliance(canInteractWO.stateSink_Toilet, "Toilet Sink");
                    }
                    break;
                                          
                case 23:
                    {
                        GoToAppliance(canInteractWO.stateSink_Bathroom, "Bathroom Sink");
                    }
                    break;
                                          
                case 24:
                    {
                        GoToAppliance(canInteractWO.stateComputer, "Computer");
                    }
                    break;

            }
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
       // ObjGoTo = Random.Range(2, 3);
        //return ObjGoTo;

      switch (roundController.roundCount) //UNCOMMENT WHEN ALL ALPIANCES ARE AVAILABLE IN THE GAME SPACE
      {
          case 0:
              ObjGoTo = Random.Range(-10, 6);
              break;
      
          case 1:
              ObjGoTo = Random.Range(-10, 10);
              break;
      
          case 2:
              ObjGoTo = Random.Range(-10, 15);
              break; 
          
          case 3:
              ObjGoTo = Random.Range(-10, 24);
              break;
      }
        return ObjGoTo;
    }
}
