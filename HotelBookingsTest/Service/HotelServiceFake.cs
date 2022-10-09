using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingsTest.Service
{
    public class HotelServiceFake : IHotelService
    {
        private readonly List<Hotel> hotels;

        public HotelServiceFake() {
            hotels = new List<Hotel>()
            {
                new Hotel() { HotelID = 1, Name = "Sahid Montana",Address="Kota Malang, Jawa Timur 65111", Description="Hotel Sahid Montana is a 4 star hotel complementend with 100+ well equipped rooms"},
                new Hotel() { HotelID = 2, Name = "FairField By Marriott", Address="Mundhwa - Kharadi Rd, Thite Nagar, Kharadi, Pune, Maharashtra 411014", Description="Our stylish hotel is conveniently located in Pune's eastern suburb of Kharadi, a short drive from Pune International Airport and near EON IT park, World Trade Center, Ranjangaon MIDC and Viman Nagar."},
                new Hotel() { HotelID = 5, Name = "Marriott Goa", Address="Miramar, Panaji, Goa 403001", Description="Situated on the edge of Miramar Beach, with picturesque views of the Arabian Sea and Mandovi River, our luxury hotel blends relaxing resort services with award-winning hospitality."}
            };
        }

        public async Task<IEnumerable<Hotel>> ListAsync(string searchtext)
        {
            if (searchtext != "")
            {
                return hotels.Where(h => h.Name.Contains(searchtext));
            }
            return hotels;
        }

        public async Task<Hotel> GetHotelAsync(int id)
        {
           
         return hotels.Where(h => h.HotelID == id).FirstOrDefault();            
           
        }

        public async Task<Result> SaveAsync(Hotel hotel)
        {
            hotel.HotelID = hotels.Select(h => hotel.HotelID).Max() + 1;
            hotels.Add(hotel);
            return Result.Success;
        }
    }
}
