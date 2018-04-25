namespace DecisionTree
{
    public class TreeDecisionFloat : TreeDecision
    {
        private readonly float minValue;
        private readonly float maxValue;
        private float floatData;
        public float FloatData
        {
            get { return floatData; }
            set { floatData = value; }
        }

        public TreeDecisionFloat(DecisionTreeAI parentObject, DecisionTreeNode falseNode, DecisionTreeNode trueNode, float minValue, float maxValue, float floatData) : base(parentObject, falseNode, trueNode)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.FloatData = floatData;
        }

        public override DecisionTreeNode getBranch()
        {
            if (FloatData <= maxValue && FloatData >= minValue) return trueNode;
            else return falseNode;
        }

        public override void UpdateValues(System.Object newValue)
        {
            FloatData = (float)newValue;
        }
    }
}
