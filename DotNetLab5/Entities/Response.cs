namespace DotNetLab5.Entities
{
    internal class Response
    {
        public bool IsSucceeded { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return IsSucceeded ? "! Transaction succeeded !" : "! Transaction is not succeeded !" +
                                                           $"\nMessage : {Message}";
        }
    }
}
