using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.Enums;

namespace Service
{
    public class APITestingService
    {
        private Repository.APITestingRepository repository;

        public APITestingService(Repository.APITestingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> SeedDbAsync()
        {
            var hotelData = new List<Hotel>() {
                new Hotel() { Name = "Sahid Montana", Address = "Kota Malang, Jawa Timur 65111", Description="Hotel Sahid Montana is a 4 star hotel complementend with 100+ well equipped rooms" },
                new Hotel() { Name = "FairField By Marriott",Address = "Mundhwa - Kharadi Rd, Thite Nagar, Kharadi, Pune, Maharashtra 411014", Description="Our stylish hotel is conveniently located in Pune's eastern suburb of Kharadi, a short drive from Pune International Airport and near EON IT park, World Trade Center, Ranjangaon MIDC and Viman Nagar." },                
                new Hotel() { Name = "Marriott Goa", Address = "Miramar, Panaji, Goa 403001", Description="Situated on the edge of Miramar Beach, with picturesque views of the Arabian Sea and Mandovi River, our luxury hotel blends relaxing resort services with award-winning hospitality." },
                new Hotel() { Name = "Double Tree By Hilton", Address = "Panaji, Goa 403001", Description="Double Tree by Hilton is a 4 star hotel whihc is oart of Hilton group and situated within the walking distance from Panaji beach." },
                new Hotel() { Name = "Park Plaza", Address = "Station Road, Pune 411012", Description="Park plaza is a 5 star hotel situated opposite to the Pune Railway Station and equipped with well maintained luxury rooms and amenities." },
                new Hotel() { Name = "Hilton Goa Resort", Address = "Pilerne - Candolim Rd, Saipem, Candolim, Goa 403515", Description="hilltop resort overlooks Goa’s lush greens and the Nerul River. We have four outdoor pools, a kids’ club and signature concierge experiences." },
            };

            var roomData = new List<Room>()
            {
                new Room() { HotelID = 1, Type = (int)RoomType.Single },
                new Room() { HotelID = 1, Type = (int)RoomType.Double },
                new Room() { HotelID = 2, Type = (int)RoomType.Deluxe },
                new Room() { HotelID = 3, Type = (int)RoomType.Single },
                new Room() { HotelID = 4, Type = (int)RoomType.Single },
                new Room() { HotelID = 4, Type = (int)RoomType.Deluxe },
                new Room() { HotelID = 5, Type = (int)RoomType.Double },
                new Room() { HotelID = 6, Type = (int)RoomType.Double },
            };

            var bookingData = new List<Booking>()
            {
                new Booking() { RoomID = 1, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 1, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 2, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 2 },
                new Booking() { RoomID = 3, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 4 },
                new Booking() { RoomID = 4, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 5, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 6, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 2 },
                new Booking() { RoomID = 7, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 8, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 2 },
                new Booking() { RoomID = 8, StartDate = DateTime.Parse("2023-07-09T00:00:00"), EndDate = DateTime.Parse("2023-07-10T00:00:00"), PartySize = 1 }
            };

            if (await repository.SeedAsync(hotelData, roomData, bookingData))
            {
                return Result.Success;
            }
            return Result.Failure;
        }

        public async Task<Result> ClearDbAsync()
        {
            if (await repository.ClearAsync())
            {
                return Result.Success;
            }
            return Result.Failure;
        }
    }
}
