using BeersAPI.Controllers;
using BeersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace BeerApiTest
{
    public class UnitTest1
    {
        [Fact]
        public async void TestInvalidRating()
        {
            var controller = new BeerRatingsController();
            var rating = new Ratings() { Username = "vishwant@gmail.com", Rating = 6, Comments = "superrr!!!!!!!" };
            int beerId = 1;
            var result=await controller.AddRating(beerId, rating);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);   

        }

        [Fact]
        public async void TestInvalidBeerID()
        {
            var controller = new BeerRatingsController();
            var rating = new Ratings() { Username = "vishwant@gmail.com", Rating = 5, Comments = "superrr!!!!!!!" };
            int invalidBeerId = 82738;
            var result = await controller.AddRating(invalidBeerId, rating);

            var badRequestResult = Assert.IsType<NotFoundObjectResult>(result);

        }
    }
}
