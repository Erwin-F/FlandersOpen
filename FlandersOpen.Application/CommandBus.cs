﻿using System;
using FlandersOpen.Application.Core;

namespace FlandersOpen.Application
{
    public sealed class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _provider;

        public CommandBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Handle((dynamic)command);

            return result;
        }
    }
}