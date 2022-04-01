namespace KevinZonda.UoB.AI.Library.Data
{
    internal class SingleLabeledData<TX, TY>
    {
        public Vector<TX> Data { get; set; }
        public TY Label { get; set; }

        public Vector<TX> X => Data;
        public TY Y => Label;

        public SingleLabeledData(Vector<TX> data, TY label)
        {
            Data = data;
            Label = label;
        }

    }
}
