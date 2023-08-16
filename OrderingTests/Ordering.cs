using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace OrderingTests
{
    public partial class Ordering
    {
        [Scenario]
        public void Successful_order()
        {
            Runner.RunScenario(
                _ => Given_the_user_is_about_to_login(),
                _ => Given_the_user_entered_valid_login("standard_user"),
                _ => Given_the_user_entered_valid_password("secret_sauce"),
                _ => When_the_user_clicks_login_button(),
                _ => Then_the_login_is_successful(),
                _ => Given_the_user_adds_an_item_to_the_cart("add-to-cart-sauce-labs-fleece-jacket"),
                _ => When_user_views_the_cart(),
                _ => Then_the_item_should_be_added_to_the_cart("Sauce Labs Fleece Jacket"),
                _ => Given_the_user_proceeds_to_checkout(),
                _ => When_the_user_inserts_personal_data("Test", "Client", "123456"),
                _ => When_the_user_clicks_continue(),
                _ => Then_the_overview_should_contain_correct_item_total("49.99"),
                _ => Then_the_overview_should_contain_correct_tax("4.00"),
                _ => Then_the_overview_should_contain_correct_total_amount("53.99"),
                _ => When_the_user_clicks_finish(),
                _ => Then_the_order_should_be_dispatched()
            );
        }




    }
}
