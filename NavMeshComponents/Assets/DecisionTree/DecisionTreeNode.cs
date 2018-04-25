namespace DecisionTree
{
    public abstract class DecisionTreeNode
    {
        protected DecisionTreeAI aiAgent;

        public DecisionTreeNode(DecisionTreeAI parentObject)
        {
            this.aiAgent = parentObject;
        }

        public virtual DecisionTreeNode MakeDecision()
        {
            return null;
        }
    }
}
