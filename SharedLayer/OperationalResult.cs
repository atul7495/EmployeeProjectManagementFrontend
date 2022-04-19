using System;

namespace SharedLayer
{
    /// <summary>
    /// Represents a result of an business operation (method call),
    /// Author : Surya Kant   
    /// </summary>
    /// <typeparam name="T">Represent the actual return type of the operation/method.</typeparam>
    public sealed class OperationalResult<T>
    {
        private bool checkedForValidity = false;
        private T data;
        public string message { get; private set; }
        public string stackTrace { get; private set; }
        /// <summary>
        /// constrcutor for intializing the data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="stackTrace"></param>
        public OperationalResult(T data, string message, string stackTrace)
        {
            this.data = data;
            this.message = message;
            this.stackTrace = stackTrace;
        }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data
        {
            get
            {
                if (!checkedForValidity)
                {
                    throw new NotSupportedException("You must check for data validity by calling IsValid() first!");
                }
                return data;
            }
            set
            {

                data = value;
            }
        }
        public static OperationalResult<T> successResult(T Data)
        {
            return new OperationalResult<T>(Data, string.Empty, string.Empty);
        }

        public static OperationalResult<T> failureResult(string failureMessage)
        {
            return new OperationalResult<T>(default(T), failureMessage, string.Empty);
        }

        public static OperationalResult<T> errorResult(string message, string StackTrace)
        {
            return new OperationalResult<T>(default, message, StackTrace);

        }
        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool isValid()
        {
            bool result = checkedForValidity = true;
            if (data == null)
                return false;
            return result;
        }
    }
}
