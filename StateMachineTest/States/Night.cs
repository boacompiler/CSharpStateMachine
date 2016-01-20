using System;
using StateMachineTest.Classes;

namespace StateMachineTest.States
{
    class Night : State
    {

        private static readonly Night instance = new Night();

        internal static Night Instance
        {
            get
            {
                return instance;
            }
        }

        private Night()
        {

        }

        public override void Enter(BaseEntity entity)
        {
            Time time = (Time)entity;
            Console.WriteLine("What a horrible night to have a curse");
        }

        public override void Update(BaseEntity entity)
        {
            Time time = (Time)entity;
            if (time.Hour > 12)
            {
                time.Hour = 0;
                time.StateMachine.ChangeState(States.Day.Instance);
            }
        }

        public override void Exit(BaseEntity entity)
        {
            Time time = (Time)entity;
        }
    }
}
