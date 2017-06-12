using System;
using System.ComponentModel;

namespace Calculator
{
    internal sealed class OperationHistory : BindingList<Operation>
    {
        private static readonly Lazy<OperationHistory> Instance = new Lazy<OperationHistory>(() => new OperationHistory());

        private OperationHistory()
        {
        }

        public static OperationHistory GetInstance => Instance.Value;
    }
}