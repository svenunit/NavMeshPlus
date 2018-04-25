namespace DecisionTree
{
    public enum ActionType
    {
        ChangeColor,
        PrintMessage
    }

    public class TreeAction : DecisionTreeNode
    {
        private ActionType actionType;
        public ActionType GetActionType()
        {
            return actionType;
        }
        public TreeAction(DecisionTreeAI parentObject, ActionType actionType) : base(parentObject)
        {
            this.actionType = actionType;
        }

        public override DecisionTreeNode MakeDecision()
        {
            aiAgent.ExecuteAction(this);
            return this;
        }
    }
}
