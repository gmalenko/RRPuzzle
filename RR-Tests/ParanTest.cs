using System;
using Xunit;
using RR;

namespace RR_Tests
{
    public class ParanTest
    {
        [Fact]        
        public void ValidateParenthesesTest1()
        {
            string input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
            var result = RR.Program.ValidateParentheses(input);
            Assert.True(result);            
        }
        
        [Fact]
        public void ValidateParenthesesTest2()
        {
            string input = "";
            var result = RR.Program.ValidateParentheses(input);
            Assert.False(result);
        }
        
        [Fact]
        public void ValidateParenthesesTest3()
        {
            string input = "(((((";
            var result = RR.Program.ValidateParentheses(input);
            Assert.False(result);
        }

        [Fact]
        public void ValidateParenthesesTest4()
        {
            string input = ")))))";
            var result = RR.Program.ValidateParentheses(input);
            Assert.False(result);
        }

        [Fact]
        public void ValidateParenthesesTest5()
        {
            string input = "((((()))))";
            var result = RR.Program.ValidateParentheses(input);
            Assert.True(result);
        }

        [Fact]
        public void ValidateParenthesesTest6()
        {
            string input = null;
            var result = RR.Program.ValidateParentheses(input);
            Assert.False(result);
        }

    }
}
