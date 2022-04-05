namespace KevinZonda.UoB.AI.Library.Methods.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MethodTagAttribute : System.Attribute
    {
        public enum LearningType
        {
            Supervised,
            Unsupervised,
            Reinforcement,
            Others
        }

        public LearningType Type { get; set; }

        public MethodTagAttribute(LearningType type)
        {
            Type = type;
        }
    }

    public class SupervisedLearningAttribute : MethodTagAttribute
    {
        public SupervisedLearningAttribute() : base(LearningType.Supervised)
        {
        }
    }

    public class UnsupervisedLearningAttribute : MethodTagAttribute
    {
        public UnsupervisedLearningAttribute() : base(LearningType.Unsupervised)
        {
        }
    }

    public class ReinforcementLearningAttribute : MethodTagAttribute
    {
        public ReinforcementLearningAttribute() : base(LearningType.Reinforcement)
        {
        }
    }

}
