using BTs;

public class ACTION_Refill : Action
{
    public ACTION_Refill()
    {
      
    }

    private ANITAs_BLACKBOARD bl;

    public override void OnInitialize()
    {
        bl = (ANITAs_BLACKBOARD)blackboard;
    }

    public override Status OnTick()
    {
        bl.apples = 3;
        bl.peaches = 3;
        bl.grapes = 3;
        bl.UpdateTexts();
        return Status.SUCCEEDED;
    }
}

