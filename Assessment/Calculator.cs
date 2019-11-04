using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public abstract class Calculator<T>
    {
        protected IEnumerable<RuleAction<T>> _ruleActions;

        public decimal Calculate(T t)
        {
            decimal total = 0;

            foreach (var ruleAction in _ruleActions)
            {
                if (ruleAction.IsTrue(t))
                {
                    total += ruleAction.ApplyCalculation(t);
                }
            }

            return Math.Ceiling(total * 20) / 20;
        }
    }
}
