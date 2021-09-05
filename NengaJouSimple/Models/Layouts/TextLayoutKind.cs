using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Layouts
{
    public enum TextLayoutKind
    {
        PostalCode,
        Address,
        Addressee,
        SenderPostalCode,
        SenderAddress,
        Sender
    }

    public static class TextLayoutKindExtension
    {
        public static string ConvertToString(this TextLayoutKind textLayoutKind)
        {
            return textLayoutKind switch
            {
                TextLayoutKind.PostalCode => nameof(TextLayoutKind.PostalCode),
                TextLayoutKind.Address => nameof(TextLayoutKind.Address),
                TextLayoutKind.Addressee => nameof(TextLayoutKind.Addressee),
                TextLayoutKind.SenderPostalCode => nameof(TextLayoutKind.SenderPostalCode),
                TextLayoutKind.SenderAddress => nameof(TextLayoutKind.SenderAddress),
                TextLayoutKind.Sender => nameof(TextLayoutKind.Sender),
                _ => throw new InvalidCastException($"{nameof(textLayoutKind)} could not convert to string.")
            };
        }

        public static TextLayoutKind ConvertFromString(string value)
        {
            return value switch
            {
                nameof(TextLayoutKind.PostalCode) => TextLayoutKind.PostalCode,
                nameof(TextLayoutKind.Address) => TextLayoutKind.Address,
                nameof(TextLayoutKind.Addressee) => TextLayoutKind.Addressee,
                nameof(TextLayoutKind.SenderPostalCode) => TextLayoutKind.SenderPostalCode,
                nameof(TextLayoutKind.SenderAddress) => TextLayoutKind.SenderAddress,
                nameof(TextLayoutKind.Sender) => TextLayoutKind.Sender,
                _ => throw new InvalidCastException($"{nameof(value)} could not convert to {nameof(TextLayoutKind)}. {nameof(value)}: {value}")
            };
        }
    }
}
