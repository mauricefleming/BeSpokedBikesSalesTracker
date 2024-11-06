﻿namespace BeSpokedBikesSalesTracker.Entities
{
// Discount.cs
public class Discount
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public double DiscountPercentage { get; set; }
}
}
