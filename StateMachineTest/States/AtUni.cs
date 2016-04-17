using System;
using StateMachineTest.Classes;

namespace StateMachineTest.States
{
    class AtUni:State
    {
        private static readonly AtUni instance = new AtUni();

        internal static AtUni Instance
        {
            get
            {
                return instance;
            }
        }

        private AtUni()
        {

        }

        public override void Enter(BaseEntity entity)
        {
            Student student = (Student)entity;
            Console.WriteLine(student.Name + ": Time to attend classes");
        }

        public override void Update(BaseEntity entity)
        {
            Student student = (Student)entity;
            student.Boredom += 1;
            Console.WriteLine(student.Name + ": i'm studying");
        }

        public override void Exit(BaseEntity entity)
        {
            Student student = (Student)entity;
            Console.WriteLine(student.Name + ": leaving is the best thing");
        }
    }
}
