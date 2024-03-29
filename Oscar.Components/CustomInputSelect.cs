﻿using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Oscar.Components
{
    public class CustomInputSelect<TValue> : InputSelect<TValue>
    {
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, 
            [NotNullWhen(false)] out string? validationErrorMessage)
        {
            if(typeof(TValue) == typeof(int))
            {
                if(int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage =
                        "Nu blev det fel i min egenskapade CustomInputSelect-metod";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}
