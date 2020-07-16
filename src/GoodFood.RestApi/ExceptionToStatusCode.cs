using System;
using GoodFood.Domain.Features.IngredientList.Exceptions;
using GoodFood.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace GoodFood.RestApi
{
    public class ExceptionToStatusCode
    {
        public static bool CanConvert(Exception exception, out IActionResult actionResult)
        {
            var convertResult = Convert(exception);
            actionResult = convertResult;

            return convertResult != null;
        }

        private static ActionResult Convert(Exception exception)
        {
            switch (exception)
            {
                case TitleLengthTooLongException _:
                    return new UnprocessableEntityObjectResult(new ErrorPayload{Message = exception.Message, ErrorType= nameof(TitleLengthTooLongException) });
                default:
                    return null;
            }
        }
    }
}