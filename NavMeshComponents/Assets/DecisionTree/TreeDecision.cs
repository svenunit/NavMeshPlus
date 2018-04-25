namespace DecisionTree
{
    public class TreeDecision : DecisionTreeNode
    {
        protected DecisionTreeNode falseNode;
        protected DecisionTreeNode trueNode;

        public TreeDecision(DecisionTreeAI parentObject, DecisionTreeNode falseNode, DecisionTreeNode trueNode) : base(parentObject)
        {
            this.falseNode = falseNode;
            this.trueNode = trueNode;
        }

        public override DecisionTreeNode MakeDecision()
        {
            DecisionTreeNode branch = getBranch();
            return branch.MakeDecision();
        }

        public virtual DecisionTreeNode getBranch()
        {
            return this;
        }

        public virtual void UpdateValues(System.Object newValue)
        {

        }
    }
}
