namespace Flights.DTOs
{
    public record NewPassengerDTO(
        string Email,
        string FirstName,
        string LastName,
        bool Gender);
    
}
