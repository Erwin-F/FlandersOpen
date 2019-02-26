using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace FlandersOpen.Application.Core
{
    public struct Result : IResult, ISerializable
    {
        private static readonly Result OkResult = new Result(false, null);

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            _logic.GetObjectData(oInfo, oContext);
        }

        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        private Result(bool isFailure, string error)
        {
            _logic = ResultCommonLogic.Create(isFailure, error);
        }

        public static Result Ok()
        {
            return OkResult;
        }

        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value, null);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, default(T), error);
        }

        public static Result<TValue, TError> Ok<TValue, TError>(TValue value) where TError : class
        {
            return new Result<TValue, TError>(false, value, default(TError));
        }

        public static Result<TValue, TError> Fail<TValue, TError>(TError error) where TError : class
        {
            return new Result<TValue, TError>(true, default(TValue), error);
        }

        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                    return Fail(result.Error);
            }

            return Ok();
        }

        public static Result Combine(string errorMessagesSeparator, params Result[] results)
        {
            List<Result> failedResults = results.Where(x => x.IsFailure).ToList();

            if (!failedResults.Any())
                return Ok();

            var errorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
            return Fail(errorMessage);
        }

        public static Result Combine(params Result[] results)
        {
            return Combine(", ", results);
        }

        public static Result Combine<T>(params Result<T>[] results)
        {
            return Combine(", ", results);
        }

        public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
        {
            Result[] untyped = results.Select(result => (Result)result).ToArray();
            return Combine(errorMessagesSeparator, untyped);
        }
    }

    public struct Result<T> : IResult, ISerializable
    {
        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            _logic.GetObjectData(oInfo, oContext);

            if (IsSuccess)
            {
                oInfo.AddValue("Value", Value);
            }
        }

        private readonly T _value;

        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return _value;
            }
        }

        internal Result(bool isFailure, T value, string error)
        {
            if (!isFailure && value == null)
                throw new ArgumentNullException(nameof(value));

            _logic = ResultCommonLogic.Create(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error);
        }
    }

    public struct Result<TValue, TError> : IResult, ISerializable
    {
        private readonly ResultCommonLogic<TError> _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public TError Error => _logic.Error;

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            _logic.GetObjectData(oInfo, oContext);

            if (IsSuccess)
            {
                oInfo.AddValue("Value", Value);
            }
        }

        private readonly TValue _value;

        public TValue Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return _value;
            }
        }

        internal Result(bool isFailure, TValue value, TError error)
        {
            if (!isFailure && value == null)
                throw new ArgumentNullException(nameof(value));

            _logic = new ResultCommonLogic<TError>(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<TValue, TError> result)
        {
            return result.IsSuccess ? Result.Ok() : Result.Fail(result.Error.ToString());
        }

        public static implicit operator Result<TValue>(Result<TValue, TError> result)
        {
            return result.IsSuccess ? Result.Ok(result.Value) : Result.Fail<TValue>(result.Error.ToString());
        }
    }
}
