using System;
using System.Linq.Expressions;

namespace SGM.Utils.ObjectExtensions {
    public static class SettingFunction {
        public static void Set<T, Q>(this T tipo, Expression<Func<Q>> propriedade, Q novoValor)
        {
            if (propriedade.Body is not MemberExpression expressao) throw new Exception("Expressão nula");

            var nomeDaPropriedade = expressao.Member.Name;
            typeof(T).GetProperty(nomeDaPropriedade).SetValue(tipo, novoValor, null);
        }
    }
}