using System;
using System.Text.RegularExpressions;

    namespace CompiFiles // Reemplaza con el espacio de nombres adecuado
{
    public class lexer
    {
        private string _source;
        private string _character;
        private int _position;
        private int _readPosition;

        public lexer(string source)
        {
            _source = source;
            _character = "";
            _position = 0;
            _readPosition = 0;
            ReadCharacter();
        }

        public Token NextToken()
        {
            SkipWhitespace();
            Token token;

            if (Regex.IsMatch(_character, @"^=$"))
            {
                if (PeekCharacter() == '=')
                {
                    token = MakeTwoCharacterToken(TokenType.EQ);
                }
                else
                {
                    token = new Token(TokenType.ASSIGN, _character);
                }
            }
            else if (Regex.IsMatch(_character, @"^>$"))
            {
                if (PeekCharacter() == '=')
                {
                    token = MakeTwoCharacterToken(TokenType.GTE);
                }
                else
                {
                    token = new Token(TokenType.GT, _character);
                }
            }
            else if (Regex.IsMatch(_character, @"^\+$"))
            {
                token = new Token(TokenType.PLUS, _character);
            }
            else if (Regex.IsMatch(_character, @"^$"))
            {
                token = new Token(TokenType.EOF, _character);
            }
            else if (IsLetter(_character))
            {
                string literal = ReadIdentifier();
                TokenType tokenType = LookupTokenType(literal);
                return new Token(tokenType, literal);
            }
            else if (IsNumber(_character))
            {
                string literal = ReadNumber();
                return new Token(TokenType.INT, literal);
            }
            else
            {
                token = new Token(TokenType.ILLEGAL, _character);
            }

            ReadCharacter();
            return token;
        }

        private bool IsLetter(string character)
        {
            return Regex.IsMatch(character, @"^[a-zA-Z]");
        }

        private bool IsNumber(string character)
        {
            return Regex.IsMatch(character, @"^\d$");
        }

        private Token MakeTwoCharacterToken(TokenType tokenType)
        {
            string prefix = _character;
            ReadCharacter();
            string suffix = _character;

            return new Token(tokenType, $"{prefix}{suffix}");
        }

        private char PeekCharacter()
        {
            if (_readPosition >= _source.Length)
            {
                return '\0';
            }
            return _source[_readPosition];
        }

        private void ReadCharacter()
        {
            if (_readPosition >= _source.Length)
            {
                _character = "";
            }
            else
            {
                _character = _source[_readPosition].ToString();
            }
            _position = _readPosition;
            _readPosition++;
        }

        private string ReadIdentifier()
        {
            int initialPosition = _position;
            while (IsLetter(_character))
            {
                ReadCharacter();
            }
            return _source.Substring(initialPosition, _position - initialPosition);
        }

        private string ReadNumber()
        {
            int initialPosition = _position;
            while (IsNumber(_character))
            {
                ReadCharacter();
            }
            return _source.Substring(initialPosition, _position - initialPosition);
        }

        private void SkipWhitespace()
        {
            while (Regex.IsMatch(_character, @"^\s$"))
            {
                ReadCharacter();
            }
        }
    }
}