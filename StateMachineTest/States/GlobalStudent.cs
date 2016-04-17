using System;
using StateMachineTest.Classes;
using StateMachineTest.Telegraph;

namespace StateMachineTest.States
{
    class GlobalStudent : State
    {
        private static readonly GlobalStudent instance = new GlobalStudent();

        internal static GlobalStudent Instance
        {
            get
            {
                return instance;
            }
        }

        private GlobalStudent()
        {

        }

        public override void Enter(BaseEntity entity)
        {
            Student student = (Student)entity;
        }

        public override void Update(BaseEntity entity)
        {
            Student student = (Student)entity;
            if (student.Boredom > 5)
            {
                Console.WriteLine(student.Name + ": I'm leaving");
                student.Boredom = 0;
                student.StateMachine.ChangeState(GoingToUni.Instance);
            }
            if (student.Fatigue > 5)
            {
                Console.WriteLine(student.Name + ": I'm tired");
                student.Fatigue = 0;
                student.StateMachine.ChangeState(AtUni.Instance);
            }
        }

        public override void Exit(BaseEntity entity)
        {
            Student student = (Student)entity;
        }

        public override void OnMessage(BaseEntity entity, MessageType message)
        {
            if (message == MessageType.Hello)
            {
                Console.WriteLine("Hi, how are you!"); //TODO this isn't being called correctly
            }
            Console.WriteLine("Hi, how are you!");
            base.OnMessage(entity, message);
        }
    }
}
