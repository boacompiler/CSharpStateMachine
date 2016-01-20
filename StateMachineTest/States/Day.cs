using System;
using StateMachineTest.Classes;

namespace StateMachineTest.States
{
    class Day : State
    {
        private static readonly Day instance = new Day();

        internal static Day Instance
        {
            get
            {
                return instance;
            }
        }

        private Day()
        {

        }

        public override void Enter(BaseEntity entity)
        {
            Time time = (Time)entity;
            Console.WriteLine("The morning sun has vanquished the horrible night");
            Telegraph.MessageDispatcher.Instance.DispatchMessage(time.ID,Program.bob.ID,1,0);
        }

        public override void Update(BaseEntity entity)
        {
            Time time = (Time)entity;
            if (time.Hour > 12)
            {
                time.Hour = 0;
                time.StateMachine.ChangeState(Night.Instance);
            }
        }

        public override void Exit(BaseEntity entity)
        {
            Time time = (Time)entity;
        }
    }
}
