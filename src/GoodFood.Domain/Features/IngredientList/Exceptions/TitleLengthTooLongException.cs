using System;

namespace GoodFood.Domain.Features.IngredientList.Exceptions
{
    public class TitleLengthTooLongException : Exception
    {
        public TitleLengthTooLongException(string message) : base(message){}
        public TitleLengthTooLongException(string title, int allowedLength) : base($"The title: '{title}' is {title.Length - allowedLength} characters longer than the allowed {allowedLength} characters.")
        {
        }
    }
}