using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace StateMachine
{

    class Program
    {
        static void Main(string[] args)
        {
            Activity workflow1 = new DealEventStateMashine();
            WorkflowInvoker.Invoke(workflow1);
            Console.ReadKey();
        }
    }
}
