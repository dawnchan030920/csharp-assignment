using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;
using CommunityToolkit.Mvvm.Input;

namespace Calculator
{
    public partial class CalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Result))]
        private string? _expression;

        public string Result => Expression == null ? "" : (new Expression(Expression)).Evaluate().ToString() ?? "";

        [RelayCommand]
        private void Number(string number)
        {
            Expression = $"{Expression}{number}";
        }

        [RelayCommand]
        private void Operator(string op)
        {
            Expression = $"{Expression}{op}";
        }

        [RelayCommand]
        private void Del()
        {
            if (Expression != null && Expression.Length > 0)
            {
                Expression = Expression.Substring(0, Expression.Length - 1);
            }
        }

        [RelayCommand]
        private void Clear()
        {
            Expression = "";
        }
    }
}
