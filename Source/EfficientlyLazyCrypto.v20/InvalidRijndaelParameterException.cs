using System;

namespace EfficientlyLazyCrypto
{
    ///<summary>
    /// Represents invalid properties within IRijndaelParameters
    ///</summary>
    public class InvalidRijndaelParameterException : Exception
    {
        ///<summary>
        /// IRijndaelParameters causing the exception
        ///</summary>
        public IRijndaelParameters Parameters { get; private set; }

        ///<summary>
        /// Invalid property within the IRijndaelParameters
        ///</summary>
        public string InvalidProperty { get; private set; }

        
        ///<summary>
        /// Invalid property value
        ///</summary>
        public object ActualValue { get; private set; }

        internal InvalidRijndaelParameterException(IRijndaelParameters parameters, string message) 
            : this (parameters, string.Empty, message)
        {
        }
        
        internal InvalidRijndaelParameterException(IRijndaelParameters parameters, string invalidProperty, string message)
            : this(parameters, invalidProperty, null, message)
        {
        }
 
        internal InvalidRijndaelParameterException(IRijndaelParameters parameters, string invalidProperty, object actualValue, string message)
            : base(message)
        {
            Parameters = parameters;
            InvalidProperty = invalidProperty;
            ActualValue = actualValue;
        }
    }
}
