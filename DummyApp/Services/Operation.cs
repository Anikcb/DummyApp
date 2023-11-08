using DummyApp.Services.Interfaces;
using System;

namespace DummyApp.Services
{
    public class Operation : IOperationScoped, IOperationTransient, IOperationSingleton
    {
        public string OperationId { get; }
        public Operation() 
        {
            OperationId = Guid.NewGuid().ToString()[^6..];
        }
    }
}
