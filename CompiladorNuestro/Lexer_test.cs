using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CompiFiles.Tests
{
    [TestClass]
    public class TestTokens
    {
        [TestMethod]
        public void TestIlegal()
        {
            string source = "¿@";
            Lexer lexer = new Lexer(source);
            List<Token> tokens = new List<Token>();
            for (int i = 0; i < source.Length; i++)
            {
                tokens.Add(lexer.NextToken());
            }
            List<Token> expectedTokens = new List<Token>
            {
                new Token(TokenType.ILLEGAL, "¿"),
                new Token(TokenType.ILLEGAL, "@")
            };
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
    }
}
