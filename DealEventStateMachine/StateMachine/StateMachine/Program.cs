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
          var result=  WorkflowInvoker.Invoke(workflow1);
       
            Console.ReadKey();
        }
    }
}
