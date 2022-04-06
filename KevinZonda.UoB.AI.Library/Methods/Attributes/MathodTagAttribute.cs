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

        public static MethodTagAttribute[] GetAttribute(Type t)
        {
            return GetCustomAttributes(t, typeof(MethodTagAttribute)) as MethodTagAttribute[];
        }
    }

    public class SupervisedAttribute : MethodTagAttribute
    {
        public SupervisedAttribute() : base(LearningType.Supervised)
        {
        }
    }

    public class UnsupervisedAttribute : MethodTagAttribute
    {
        public UnsupervisedAttribute() : base(LearningType.Unsupervised)
        {
        }
    }

    public class ReinforcementAttribute : MethodTagAttribute
    {
        public ReinforcementAttribute() : base(LearningType.Reinforcement)
        {
        }
    }

}
