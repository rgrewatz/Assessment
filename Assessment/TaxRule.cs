using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public class TaxAction<T> where T : Financial
    {
        private Func<T, bool> _ruleExpression;
        private Func<T, decimal> _taxAction;
        public TaxAction(Func<T, bool> ruleExpression, Func<T, decimal> taxAction)
        {
            _ruleExpression = ruleExpression;
            _taxAction = taxAction;
        }

        private bool IsTrue(T t)
        {
            return _ruleExpression.Invoke(t);
        }

        public decimal Apply(T t)
        {
            return IsTrue(t) ? _taxAction.Invoke(t) : 0;
        }
    }
}
