using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DecisionTree
{
    public class DecisionTreeAI : MonoBehaviour
    {
        private Material mat;
        private UnityEngine.AI.NavMeshAgent navMeshAgent;
        private DecisionTreeNode[] tree = new DecisionTreeNode[3];

        private Dictionary<ActionType, Action> actionDict = new Dictionary<ActionType, Action>();

        private float SpeedData()
        {
            return navMeshAgent.speed;
        }
        private void Awake()
        {
            mat = GetComponent<Renderer>().material;
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            tree[2] = new TreeAction(this, ActionType.ChangeColor);
            tree[1] = new TreeAction(this, ActionType.PrintMessage);
            tree[0] = new TreeDecisionFloat(this, tree[1], tree[2], 5f, 10f, SpeedData());

            actionDict.Add(ActionType.ChangeColor, () => ChangeColor(Color.red));
            actionDict.Add(ActionType.PrintMessage, () => PrintMessage());

        }

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                tree[0].MakeDecision();
            }
        }

        public void ExecuteAction(TreeAction action)
        {
            ActionType type = action.GetActionType();
            if (actionDict.ContainsKey(type))
            {
                actionDict[type].Invoke();
            }
        }

        private void ChangeColor(Color newColor)
        {
            mat.color = newColor;
        }

        private void PrintMessage()
        {
            print("This is a message!");
        }
    }
}

