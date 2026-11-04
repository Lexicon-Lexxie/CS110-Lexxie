namespace HelloInvestigation
{
    public class Greeting
    {
        // Property to hold the person's name (defaults to "runner")
        public string Name { get; set; } = "runner";

        // Method that formats and returns the greeting string
        public string BuildMessage()
        {
            return $"Hello, world, {Name}!";
        }
    }
}