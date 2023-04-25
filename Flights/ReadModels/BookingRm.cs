namespace Flights.ReadModels
{
    public record BookingRm(
        Guid FlightID,
        string Airline,
        string Price,
        TimePlaceRm Arrival,
        TimePlaceRm Departure,
        int? NumberOfBookedSeats,
        string PassengerEmail);
    
}
