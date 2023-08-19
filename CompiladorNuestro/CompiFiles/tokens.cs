using System;
using System.Collections.Generic;
namespace CompiFiles
public enum TokenType
{
    ASSING,
    COMMA,
    DIF,
    ELSE,
    EOF,
    EQ,
    FUNCTION,
    IDENTIFIER,
    IF,
    GT,
    GTE,
    ILLEGAL,
    INTEGER,
    LBRACE,
    LET,
    LPAREN,
    LT,
    LTE,
    MINUS,
    NEGATION,
    PLUS,
    RBRACE,
    RPAREN,
    SEMICOLON
}

public class Token
{
    public TokenType TokenType { get; }
    public string Literal { get; }

    public Token(TokenType tokenType, string literal)
    {
        TokenType = tokenType;
        Literal = literal;
    }

    public override string ToString()
    {
        return $"Type: {TokenType}, Literal: {Literal}";
    }
}
public class TokenLookup
{
    public TokenType LookupTokenType(string literal)
    {
        Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>()
        {
            { "funcion", TokenType.FUNCTION },
            { "variable", TokenType.LET },
            { "si", TokenType.IF },
            { "sino", TokenType.ELSE }
        };

        if (keywords.TryGetValue(literal, out TokenType tokenType))
        {
            return tokenType;
        }

        return TokenType.IDENTIFIER;
    }
}