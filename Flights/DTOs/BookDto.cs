namespace Flights.DTOs
{
    public record BookDto(Guid FlightId,
        string PassengerEmail,
        byte? NumberOfSeats);
    
}
