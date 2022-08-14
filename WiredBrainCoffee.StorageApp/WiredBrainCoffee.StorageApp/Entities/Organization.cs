namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Organization : EntityBase
    {
        public string? FirstName { get; set; }
        public override string ToString() => $"Id: {Id}, Name: {FirstName}";
    }
}
