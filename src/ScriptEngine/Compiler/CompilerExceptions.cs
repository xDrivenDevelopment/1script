﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptEngine.Compiler
{
    public class CompilerException : ScriptException
    {
        internal CompilerException(string msg)
            : base(new CodePositionInfo(), msg)
        {

        }

        internal static CompilerException AppendCodeInfo(CompilerException exc, int line, string codeString)
        {
            exc.LineNumber = line;
            exc.Code = codeString;
            return exc;
        }

        internal static CompilerException AppendCodeInfo(CompilerException exc, CodePositionInfo codePosInfo)
        {
            AppendCodeInfo(exc, codePosInfo.LineNumber, codePosInfo.Code);
            return exc;
        }

        internal static CompilerException UnexpectedOperation()
        {
            return new CompilerException("Неизвестная операция");
        }

        internal static CompilerException IdentifierExpected()
        {
            return new CompilerException("Ожидается идентификатор");
        }

        internal static CompilerException SemicolonExpected()
        {
            return new CompilerException("Ожидается символ ; (точка с запятой)");
        }

        internal static CompilerException LateVarDefinition()
        {
            return new CompilerException("Объявления переменных должны быть расположены в начале модуля, процедуры или функции");
        }

        internal static CompilerException TokenExpected(params Token[] expected)
        {
            var names = expected.Select(x => Enum.GetName(typeof(Token), x));
            return new CompilerException("Ожидается символ: " + String.Join("/", names));
        }

        internal static CompilerException TokenExpected(string tokens)
        {
            return new CompilerException("Ожидается символ: " + tokens);
        }

        internal static CompilerException ExpressionSyntax()
        {
            return new CompilerException("Ошибка в выражении");
        }

        internal static CompilerException UseProcAsFunction()
        {
            return new CompilerException("Использование процедуры, как функции");
        }

        internal static CompilerException TooLittleArgumentsPassed()
        {
            return new CompilerException("Недостаточно фактических параметров");
        }

        internal static CompilerException TooManyArgumentsPassed()
        {
            return new CompilerException("Слишком много фактических параметров");
        }

        internal static CompilerException ArgHasNoDefaultValue(int argNum)
        {
            return new CompilerException(string.Format("Аргумент {0} не имеет значения по умолчанию", argNum));
        }

        internal static CompilerException InternalCompilerError(string reason)
        {
            return new CompilerException("Внутренняя ошибка компилятора:" + reason);
        }

        internal static CompilerException UnexpectedEndOfText()
        {
            return new CompilerException("Обнаружено логическое завершение текста модуля");
        }

        internal static CompilerException BreakOutsideOfLoop()
        {
            return new CompilerException("Оператор \"Прервать\" может использоваться только внутри цикла");
        }

        internal static CompilerException ContinueOutsideOfLoop()
        {
            return new CompilerException("Оператор \"Продолжить\" может использоваться только внутри цикла");
        }

        internal static CompilerException ReturnOutsideOfMethod()
        {
            return new CompilerException("Оператор \"Возврат\" может использоваться только внутри метода");
        }

        internal static CompilerException ProcReturnsAValue()
        {
            return new CompilerException("Процедуры не могут возвращать значение");
        }

        internal static CompilerException FuncEmptyReturnValue()
        {
            return new CompilerException("Функция должна возвращать значение");
        }
        
        internal static CompilerException MismatchedRaiseException()
        {
            return new CompilerException("Оператор \"ВызватьИсключение\" без параметров может использоваться только в блоке \"Исключение\"");
        }

    }

    public class ExtraClosedParenthesis : CompilerException
    {
        internal ExtraClosedParenthesis(CodePositionInfo codePosInfo) : base("Ожидается символ: (")
        {
            this.LineNumber = codePosInfo.LineNumber;
            this.Code = codePosInfo.Code;
        }
    }

}
