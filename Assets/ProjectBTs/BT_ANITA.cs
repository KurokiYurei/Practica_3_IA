using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_ANITA", menuName = "Behaviour Trees/BT_ANITA", order = 1)]
public class BT_ANITA : BehaviourTree
{
    /* If necessary declare BT parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 
     */

    // construtor
    public BT_ANITA()
    {
        /* Receive BT parameters and set them. Remember all are of type string */
    }

    public override void OnConstruction()
    {
        /* Write here (method OnConstruction) the code that constructs the Behaviour Tree 
           Remember to set the root attribute to a proper node
           e.g.
            ...
            root = new SEQUENCE();
            ...

          A behaviour tree can use other behaviour trees.  
      */

        DynamicSelector main = new DynamicSelector();

        main.AddChild(
            new CONDITION_CustomerInStore(),
            new BT_CUSTOMER_ENTERS_STORE()
            );

        main.AddChild(
            new CONDITION_AlwaysTrue(),
            new BT_SWEEP_AND_SING()
            );

        root = main;
    }
}

public class BT_SWEEP_AND_SING : BehaviourTree
{
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_ClearUtterance(),
            new ACTION_Activate("theBroom"),
            new ACTION_Activate("theNotes"),
            new ACTION_WanderAround("theSweepingPoint", "0.5")
            );
    }
}

public class BT_CUSTOMER_ENTERS_STORE : BehaviourTree
{
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_Deactivate("theBroom"),
            new ACTION_Deactivate("theNotes"),
            new ACTION_Utter("10", "3"),
            new ACTION_Arrive("theFrontOfDesk")

            );
    }
}