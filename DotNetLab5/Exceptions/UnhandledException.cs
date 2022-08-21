namespace DotNetLab5.Exceptions
{
    internal class UnhandledException : Exception
    {
        public UnhandledException(string handlerName)
        : base($"Unable to handle transaction in '{handlerName}'") 
        { }
    }
}
