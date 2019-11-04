using System;

namespace Assessment
{
    public class RuleAction<T>
    {
        private Func<T, bool> _ruleExpression;
        private Func<T, decimal> _ruleAction;
        public RuleAction(Func<T, bool> ruleExpression, Func<T, decimal> ruleAction)
        {
            _ruleExpression = ruleExpression;
            _ruleAction = ruleAction;
        }

        public bool IsTrue(T t)
        {
            return _ruleExpression?.Invoke(t) ?? false;
        }

        public decimal Apply(T t)
        {
            return IsTrue(t) ? (_ruleAction?.Invoke(t) ?? 0) : 0;
        }
    }
}
