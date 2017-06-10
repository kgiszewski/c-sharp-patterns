using System;
using System.Collections.Generic;
using System.Linq;
using DynamicDispatch.Messaging.Handlers;

namespace DynamicDispatch.Messaging.Helpers
{
    public static class MessageHelper
    {
        private static IEnumerable<Type> _allHandlerTypes;
        private static string _handlerSuffix = "Handler";
        private static string _messageSuffix = "Message";

        //based on message name, fine the corresponding handler type
        public static Type GetMessageHandlerByMessageTypeName(string messageType)
        {
            var handler = GetAllMessageHandlers()
                .FirstOrDefault(x => x.Name.ToHandlerName() == messageType);

            return handler;
        }

        //reflection utility to cache the known handler types
        public static IEnumerable<Type> GetAllMessageHandlers()
        {
            if (_allHandlerTypes != null) return _allHandlerTypes;

            var openGenericType = typeof(IHandleMessages<>);

            _allHandlerTypes = from x in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                from z in x.GetInterfaces()
                let y = x.BaseType
                where
                ((y != null && y.IsGenericType && openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition()))
                 || (z.IsGenericType && openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition())))
                && !x.IsAbstract && !x.IsInterface
                select x;

            return _allHandlerTypes;
        }

        //given an input, returns the raw message name when given a handler name
        public static string ToHandlerName(this string input)
        {
            if (input == null)
            {
                return string.Empty;
            }

            return !input.EndsWith(_handlerSuffix) ? input : input.Remove(input.LastIndexOf(_handlerSuffix));
        }

        //given an input, returns the raw message name when given a message name
        public static string ToMessageName(this string input)
        {
            if (input == null)
            {
                return string.Empty;
            }

            return !input.EndsWith(_messageSuffix) ? input : input.Remove(input.LastIndexOf(_messageSuffix));
        }
    }
}
