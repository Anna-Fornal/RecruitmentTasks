using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System.Net;
using ApiTester.Domain;
namespace ApiTester
{
    [FeatureDescription(
        @"In order to manage users database
As as Api client
I want to be able to retrieve existing users")]
    public partial class Retrieving_users
        /* Below there are two scenarios: one detailed and the other one more generic
         * The detailed scenario contains one method for each property - this makes easier to assess why tests failed but slightly more difficult to manage
         * The generic scenario is easier to manage, but when tests fail it's more difficult to assess which property was faulty
         */
    {
        [Scenario]
        public async Task Retrieving_user_by_id_detailed()
        {
            await Runner.RunScenarioAsync(
                _ => Given_an_id_of_an_existing_user(1),
                _ => When_I_request_the_user_by_id(),
                _ => Then_the_response_should_have_status_code(HttpStatusCode.OK),
                _ => Then_the_response_should_contain_user_details(),
                _ => Then_the_response_should_contain_correct_user_id(1),
                _ => Then_the_response_should_contain_correct_user_name("Leanne Graham"),
                _ => Then_the_response_should_contain_correct_user_username("Bret"),
                _ => Then_the_response_should_contain_correct_user_email("Sincere@april.biz"),
                _ => Then_response_should_contain_user_address(),
                _ => Then_the_response_should_contain_correct_user_address_street("Kulas Light"),
                _ => Then_the_response_should_contain_correct_user_address_suite("Apt. 556"),
                _ => Then_the_response_should_contain_correct_user_address_city("Gwenborough"),
                _ => Then_the_response_should_contain_correct_user_address_zipcode("92998-3874"),
                _ => Then_the_response_should_contain_address_geo(),
                _ => Then_the_response_should_contain_correct_user_address_geo_lat("-37.3159"),
                _ => Then_the_response_should_contain_correct_user_address_geo_lng("81.1496"),
                _ => Then_the_response_should_contain_correct_user_phone("1-770-736-8031 x56442"),
                _ => Then_the_response_should_contain_correct_user_website("hildegard.org"),
                _ => Then_the_response_should_contain_user_company(),
                _ => Then_the_response_should_contain_correct_user_company_name("Romaguera-Crona"),
                _ => Then_the_response_should_contain_correct_user_company_CatchPhrase("Multi-layered client-server neural-net"),
                _ => Then_the_response_should_contain_correct_user_company_bs("harness real-time e-markets")

                );
        }
        [Scenario]
        public async Task Retrieving_user_by_id()
        {
            await Runner.RunScenarioAsync(
                _ => Given_an_id_of_an_existing_user(1),
                _ => When_I_request_the_user_by_id(),
                _ => Then_the_response_should_have_status_code(HttpStatusCode.OK),
                _ => Then_the_response_should_contain_user_details(),
                _ => Then_the_response_should_contain_correct_user(new User
                {
                    id = 1,
                    name = "Leanne Graham",
                    username = "Bret",
                    email = "Sincere@april.biz",
                    address = new Address
                    {
                        street = "Kulas Light",
                        suite = "Apt. 556",
                        city = "Gwenborough",
                        zipcode = "92998-3874",
                        geo = new Geo
                        {
                            lat = "-37.3159",
                            lng = "81.1496"
                        }
                    },
                    phone = "1-770-736-8031 x56442",
                    website = "hildegard.org",
                    company = new Company
                    {
                        name = "Romaguera-Crona",
                        catchPhrase = "Multi-layered client-server neural-net",
                        bs = "harness real-time e-markets"
                    }
                })

                );
        }
    }
}