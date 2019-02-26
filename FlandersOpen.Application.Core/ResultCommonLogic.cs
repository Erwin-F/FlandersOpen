using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace FlandersOpen.Application.Core
{
    internal class ResultCommonLogic<TError>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly TError _error;

        public TError Error
        {
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no error message for success.");

                return _error;
            }
        }

        public ResultCommonLogic(bool isFailure, TError error)
        {
            if (isFailure)
            {
                if (error == null)
                    throw new ArgumentNullException(nameof(error), ResultMessages.ErrorObjectIsNotProvidedForFailure);
            }
            else
            {
                if (error != null)
                    throw new ArgumentException(ResultMessages.ErrorObjectIsProvidedForSuccess, nameof(error));
            }

            IsFailure = isFailure;
            _error = error;
        }

        public void GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("IsFailure", IsFailure);
            oInfo.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                oInfo.AddValue("Error", Error);
            }
        }
    }

    internal sealed class ResultCommonLogic : ResultCommonLogic<string>
    {
        [DebuggerStepThrough]
        public static ResultCommonLogic Create(bool isFailure, string error)
        {
            if (isFailure)
            {
                if (string.IsNullOrEmpty(error))
                    throw new ArgumentNullException(nameof(error), ResultMessages.ErrorMessageIsNotProvidedForFailure);
            }
            else
            {
                if (error != null)
                    throw new ArgumentException(ResultMessages.ErrorMessageIsProvidedForSuccess, nameof(error));
            }

            return new ResultCommonLogic(isFailure, error);
        }

        public ResultCommonLogic(bool isFailure, string error) : base(isFailure, error)
        {
        }
    }
}
