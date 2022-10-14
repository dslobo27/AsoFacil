using NSubstitute;
using NSubstitute.Core;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Tests
{
    public static class NSubstituteExtensions
    {
        public static ConfiguredCall TaskThrowsException<T>(this Task<T> task, string message = null)
        {
            return TaskThrows<T, Exception>(task, message);
        }

        public static ConfiguredCall TaskThrows<T, TException>(this Task<T> task, string message = null)
            where TException : Exception
        {
            return TaskThrows(task, typeof(TException));
        }

        public static ConfiguredCall TaskThrows<T>(this Task<T> task, Type exceptionType, string message = null)
        {
            if (!typeof(Exception).IsAssignableFrom(exceptionType))
                throw new ArgumentException($"Type has to be a subclass of System.Exception", nameof(exceptionType));

            var exception = Activator.CreateInstance(exceptionType, message) as Exception;
            return TaskThrows(task, exception);
        }

        public static ConfiguredCall TaskThrows<T>(this Task<T> task, Exception exception)
        {
            return task.Returns(Task.FromException<T>(exception));
        }

        public static ConfiguredCall TaskThrows<TException>(this Task task, string message = null)
            where TException : Exception
        {
            return TaskThrows(task, typeof(TException));
        }

        public static ConfiguredCall TaskThrows(this Task task, Type exceptionType, string message = null)
        {
            if (!typeof(Exception).IsAssignableFrom(exceptionType))
                throw new ArgumentException($"Type has to be a subclass of System.Exception", nameof(exceptionType));

            var exception = Activator.CreateInstance(exceptionType, message) as Exception;
            return TaskThrows(task, exception);
        }

        public static ConfiguredCall TaskThrows(this Task task, Exception exception)
        {
            return task.Returns(Task.FromException(exception));
        }
    }
}