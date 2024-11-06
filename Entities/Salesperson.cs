namespace BeSpokedBikesSalesTracker.Entities
{
        public class Salesperson
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public required string Manager { get; set; }
    }
}
