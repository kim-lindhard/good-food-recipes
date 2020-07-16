using System;
using GoodFood.Domain.Features.IngredientList.Exceptions;
using Newtonsoft.Json;

namespace GoodFood.RestClient
{
    public static class HttpResponseContentToException
    {
        public static Exception Convert(string content)
        {
           
            var errorPayload = JsonConvert.DeserializeObject<ErrorPayload>(content);

            
            switch (errorPayload.ErrorType)
            {
                case  "TitleLengthTooLongException":
                    return new TitleLengthTooLongException(errorPayload.Message);
                default:
                    return new Exception(errorPayload.Message);
            }
        }
    }
}