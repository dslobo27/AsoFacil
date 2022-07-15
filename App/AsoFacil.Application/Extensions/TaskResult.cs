using System.Collections.Generic;

namespace AsoFacil.Application.Extensions
{
    public class TaskResult<T>
    {
        public TaskResult(T data)
        {
            Data = data;
        }

        public TaskResult(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public TaskResult(string error)
        {
            Errors.Add(error);
        }

        public TaskResult(List<string> errors)
        {
            Errors = errors;
        }

        public T Data { get; set; }
        public List<string> Errors { get; private set; } = new List<string>();
    }
}