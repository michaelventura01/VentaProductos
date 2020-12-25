using System;
using System.Text;

namespace MARDOMAPI.Models
{
    public class RandomGenerator
    {
        private readonly Random _random = new Random();  
    
        public int RandomNumber(int min, int max)  
        {  
        return _random.Next(min, max);  
        }  
    
        public string RandomString(int size, bool lowerCase = false)  
        {  
        var builder = new StringBuilder(size);  
        char offset = lowerCase ? 'a' : 'A';  
        const int lettersOffset = 26;
    
        for (var i = 0; i < size; i++)  
        {  
            var @char = (char)_random.Next(offset, offset + lettersOffset);  
            builder.Append(@char);  
        }  
    
        return lowerCase ? builder.ToString().ToLower() : builder.ToString();  
        }  
        public string RandomPassword()  
        {  
        var passwordBuilder = new StringBuilder();  
    
        passwordBuilder.Append(RandomString(4, true));  
    
        passwordBuilder.Append(RandomNumber(1000, 9999));  
    
        passwordBuilder.Append(RandomString(2));  
        return passwordBuilder.ToString();  
        }  
    }
}