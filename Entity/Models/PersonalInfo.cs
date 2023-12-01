﻿namespace Entity.Models;

public class PersonalInfo : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string MobileNo { get; set; }
    public string Email { get; set; }
    public string PasportNo { get; set; }
    public string NID { get; set; }
}