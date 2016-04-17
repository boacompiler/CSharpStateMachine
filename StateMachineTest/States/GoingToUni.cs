using System;
using StateMachineTest.Classes;

namespace StateMachineTest.States
{
    class GoingToUni : State
    {
        private static readonly GoingToUni instance = new GoingToUni();

        internal static GoingToUni Instance
        {
            get
            {
                return instance;
            }
        }

        private GoingToUni()
        {

        }

        public override void Enter(BaseEntity entity)
        {
            Student student = (Student)entity;
            Console.WriteLine(student.Name+": nearly missed my train");
        }

        public override void Update(BaseEntity entity)
        {
            Student student = (Student)entity;
            student.Fatigue += 1;
            Console.WriteLine(student.Name + ": *Checks Phone* Gahh, i'll be late");

        }

        public override void Exit(BaseEntity entity)
        {
            Student student = (Student)entity;
            Console.WriteLine(student.Name + ": Well, I'm here");
        }
    }
}
