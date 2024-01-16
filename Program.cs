using Newtonsoft.Json;
using WeatherApp3.Models;

public class Program
{
    public static async Task Main()
    {
        bool run = true;
        while(run) {
        
        Console.Write("Location             : ");
        
        string location = Console.ReadLine();

        string key = "7526426584514abfbeb162945241601";

        // Specify the URL of the API you want to call
        string apiUrl = "https://api.weatherapi.com/v1/current.json?key= " + key + "&q=" + location + "&aqi=yes";


            // Create an instance of HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Make a GET request
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    // Check if the request was successful (status code 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Mayweather weather = JsonConvert.DeserializeObject<Mayweather>(apiResponse);

                        Console.WriteLine("Country          : " + weather.location.country);
                        Console.WriteLine("Region           : " + weather.location.region);
                        Console.WriteLine("Latitude         : " + weather.location.lat);
                        Console.WriteLine("Longitude        : " + weather.location.lon);
                        Console.WriteLine("Local Time       : " + weather.location.localtime);

                        string day = "Night";

                        if (weather.current.is_day == true)
                        {
                            day = "Morning";
                        }
                        Console.WriteLine("Timne of The Day : " + day);
                        Console.WriteLine("Temperature      : " + weather.current.temp_c);
                        Console.WriteLine("Wind Direction   : " + weather.current.wind_dir);
                        Console.WriteLine("Wind Speed       : " + weather.current.wind_kph);






                    }
                    else
                    {
                        // Handle unsuccessful API call
                        Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    }

                    Console.Write("Do you want to search again? (yes/no)    :    ");
                    string run_again = Console.ReadLine();
                    if(run_again != "yes")
                    {
                        run = false;
                    }else
                    {
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
        }
    }
}
