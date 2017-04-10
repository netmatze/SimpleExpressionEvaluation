using System;
using SimpleExpressionEvaluator;
using SimpleExpressionEvaluator.Lexer;
using SimpleExpressionEvaluator.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleExpressionEvaluatorTests
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Children { get; set; }
        public bool Married { get; set; }
    }

    [TestClass]
    public class ExpressionEvaluatorTest
    {
        [TestMethod]
        public void ExpressionStringTest()
        {
            string text = " Name = 'mathias' ";
            Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void ExpressionBoolTest()
        {
            string text = " Married = true ";
            Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void ExpressionIntegerTest()
        {
            string text = " Age = 5 * 6 + 7 - 1 ";
            Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void ExpressionModuloTest()
        {
            string text = " Age = 100 % 64 ";
            Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
            Assert.AreEqual<bool>(result, true);
        }

        [TestMethod]
        public void ExpressionTest()
        {
            //string text = " test > 10 ";
            //string text = " 5 + 3 > 2 * 1 ";
            //string text = " 5 * 3 + 2 * 1 ";    
            //string text = " Children * 2 + 5 = 9 && Married = true && Age = (5 * 6 + 7 - 1) "; //|| Name = 'mathias'
            //string text = " Children * 2.0 + 5.0 = 9.0 ";
            //string text = " Children * 2.0 + 5.0 = 9.0 && Married = true && Age = Children * 18 ";
            var text = " Children >= Age / 20 && Name != 'test' ";
            Person person = new Person() { Name = "mathias", Age = 36, Children = 2, Married = true };
            ExpressionEvaluatorLexer expressionEvaluatorLexer = new ExpressionEvaluatorLexer(text, 1);
            ExpressionEvaluatorParser expressionEvaluatorParser = new ExpressionEvaluatorParser(expressionEvaluatorLexer);
            var AbstractSyntaxTreeNodeList = expressionEvaluatorParser.BuildParseTree();
            ExpressionEvaluatorExecutor expressionEvaluator = new ExpressionEvaluatorExecutor();
            var result = expressionEvaluator.Evaluate<Person>(AbstractSyntaxTreeNodeList, expressionEvaluatorParser.SymbolTable, person);
            Assert.AreEqual<bool>(result, true);
        }
    }
}
