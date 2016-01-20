using System;
using StateMachineTest.Classes;

namespace StateMachineTest.States
{
    class GlobalTime : State
    {
        private static readonly GlobalTime instance = new GlobalTime();

        internal static GlobalTime Instance
        {
            get
            {
                return instance;
            }
        }

        private GlobalTime()
        {

        }

        public override void Enter(BaseEntity entity)
        {
            Time time = (Time)entity;
        }

        public override void Update(BaseEntity entity)
        {
            Time time = (Time)entity;
            time.Hour += 1;
        }

        public override void Exit(BaseEntity entity)
        {
            Time time = (Time)entity;
        }
    }
}
