using LightBDD.Framework;
using LightBDD.XUnit2;
using System.Net;
using ApiTester.Domain;
using System.Text.Json;

namespace ApiTester
{
    public partial class Retrieving_users : FeatureFixture
    {
        private readonly HttpClient _client;
        private State<HttpResponseMessage> _response;
        private State<int> _userId;
        private State<User> _actualUser;
        private State<User> _expectedUser;

        public Retrieving_users()
        {
            _client = new HttpClient();
        }

        private async Task Given_an_id_of_an_existing_user(int userId)
        {
            _userId = userId;
        }

        private async Task When_I_request_the_user_by_id()
        {
            _response = await _client.GetAsync("https://jsonplaceholder.typicode.com/users/" + _userId);
        }

        private async Task Then_the_response_should_have_status_code(HttpStatusCode code)
        {
            Assert.Equal(code, _response.GetValue().StatusCode);
        }

        private async Task Then_the_response_should_contain_user_details()
        {
            string json = await _response.GetValue().Content.ReadAsStringAsync();
            _actualUser = JsonSerializer.Deserialize<User>(json);
            Assert.NotNull(_actualUser);
        }

        private async Task Then_the_response_should_contain_correct_user_id(int expectedId)
        {
            var actual = _actualUser.GetValue();
            Assert.Equal(expectedId, actual.id);
        }
        private async Task Then_the_response_should_contain_correct_user_name(string expectedName)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedName, actual.name);
        }

        private async Task Then_the_response_should_contain_correct_user_username(string expectedUsername)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedUsername, actual.username);
        }
        private async Task Then_the_response_should_contain_correct_user_email(string expectedEmail)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedEmail, actual.email);
        }

        private async Task Then_response_should_contain_user_address()
        {
            var actual = _actualUser.GetValue()!;
            Assert.NotNull(actual.address);
        }
        private async Task Then_the_response_should_contain_correct_user_address_street(string expectedStreet)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedStreet, actual.address.street);
        }
        private async Task Then_the_response_should_contain_correct_user_address_suite(string expectedSuite)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedSuite, actual.address.suite);
        }
        private async Task Then_the_response_should_contain_correct_user_address_city(string expectedCity)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedCity, actual.address.city);
        }
        private async Task Then_the_response_should_contain_correct_user_address_zipcode(string expectedZipcode)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedZipcode, actual.address.zipcode);
        }
        private async Task Then_the_response_should_contain_address_geo()
        {
            var actual = _actualUser.GetValue()!;
            Assert.NotNull(actual.address.geo);
        }
        private async Task Then_the_response_should_contain_correct_user_address_geo_lat(string expectedLat)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedLat, actual.address.geo.lat);
        }

        private async Task Then_the_response_should_contain_correct_user_address_geo_lng(string expectedLng)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedLng, actual.address.geo.lng);
        }

        private async Task Then_the_response_should_contain_correct_user_phone(string expectedPhone)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedPhone, actual.phone);
        }
        private async Task Then_the_response_should_contain_correct_user_website(string expectedWebsite)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedWebsite, actual.website);
        }
        private async Task Then_the_response_should_contain_user_company()
        {
            var actual = _actualUser.GetValue()!;
            Assert.NotNull(actual.company);
        }
        private async Task Then_the_response_should_contain_correct_user_company_name(string expectedCompanyName)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedCompanyName, actual.company.name);
        }

        private async Task Then_the_response_should_contain_correct_user_company_CatchPhrase(string expectedCompanyCatchPhrase)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedCompanyCatchPhrase, actual.company.catchPhrase);
        }

        private async Task Then_the_response_should_contain_correct_user_company_bs(string expectedCompanyBs)
        {
            var actual = _actualUser.GetValue()!;
            Assert.Equal(expectedCompanyBs, actual.company.bs);
        }

        private async Task Then_the_response_should_contain_correct_user(User expectedUser)
        {
            var actual = _actualUser.GetValue()!;

            Assert.NotNull(actual);
            Assert.Equal(expectedUser.id, actual.id);
            Assert.Equal(expectedUser.name, actual.name);
            Assert.Equal(expectedUser.username, actual.username);
            Assert.Equal(expectedUser.email, actual.email);

            Assert.NotNull(actual.address);
            Assert.Equal(expectedUser.address.street, actual.address.street);
            Assert.Equal(expectedUser.address.suite, actual.address.suite);
            Assert.Equal(expectedUser.address.city, actual.address.city);
            Assert.Equal(expectedUser.address.zipcode, actual.address.zipcode);

            Assert.NotNull(actual.address.geo);
            Assert.Equal(expectedUser.address.geo.lat, actual.address.geo.lat);
            Assert.Equal(expectedUser.address.geo.lng, actual.address.geo.lng);

            Assert.Equal(expectedUser.phone, actual.phone);
            Assert.Equal(expectedUser.website, actual.website);

            Assert.NotNull(actual.company);
            Assert.Equal(expectedUser.company.name, actual.company.name);
            Assert.Equal(expectedUser.company.catchPhrase, actual.company.catchPhrase);
            Assert.Equal(expectedUser.company.bs, actual.company.bs);
        }
    }
    }
