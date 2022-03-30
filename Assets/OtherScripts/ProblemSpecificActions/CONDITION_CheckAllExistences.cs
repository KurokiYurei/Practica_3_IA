using BTs;

public class CONDITION_CheckAllExistences : Condition
{

    public string keyItem1;
    public string keyItem2;
    public string keyItem3;

    public CONDITION_CheckAllExistences(string keyItem1, string keyItem2, string keyItem3)
    {
        this.keyItem1 = keyItem1;
        this.keyItem2 = keyItem2;
        this.keyItem3 = keyItem3;
    }


    public override bool Check()
    {
        ANITAs_BLACKBOARD blackboard = GetComponent<ANITAs_BLACKBOARD>();
        int count = 0;
        if (!blackboard.CheckExistences(blackboard.Get<string>(keyItem1))) count++;
        if (!blackboard.CheckExistences(blackboard.Get<string>(keyItem2))) count++;
        if (!blackboard.CheckExistences(blackboard.Get<string>(keyItem3))) count++;

        return count == 3;
    }

}
