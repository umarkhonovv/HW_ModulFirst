using CRUD_Post.Models;

namespace CRUD_Post.Servicesl
{
    public class RestaurantService
    {
        private List<Restaurant> restaurants;

        public RestaurantService()
        {
            restaurants = new List<Restaurant>();
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = Guid.NewGuid();
            restaurants.Add(restaurant);

            return restaurant;
        }
        public Restaurant GetById(Guid id)
        {
            foreach (var restaurant in restaurants)
            {
                if (restaurant.Id == id)
                {
                    return restaurant;
                }
            }

            return null;
        }
        public bool Delete(Guid id)
        {
            var restaurant = GetById(id);
            if (restaurant is null)
            {
                return false;
            }
            var index = restaurants.IndexOf(restaurant);
            restaurants.Remove(restaurants[index]);

            return true;
        }
        public bool Update(Restaurant restaurant)
        {
            var result = GetById(restaurant.Id);
            if (result is null)
            {
                return false;
            }
            var index = restaurants.IndexOf(result);
            restaurants[index] = restaurant;

            return true;
        }
        public List<Restaurant> GettAll()
        {
            return restaurants;
        }
        public Restaurant GetTopRatedRestaurant()
        {
            var topRestaurant = new Restaurant();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.Rating > topRestaurant.Rating)
                {
                    topRestaurant = restaurant;
                }
            }

            return topRestaurant;
        }
        public Restaurant GetRestaurantWithMostDishes()
        {
            var restaurabtWithMostDishes = new Restaurant();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.Dishes.Count > restaurabtWithMostDishes.Dishes.Count)
                {
                    restaurabtWithMostDishes = restaurant;
                }
            }

            return restaurabtWithMostDishes;
        }
        public List<Restaurant> GetRestaurantsByLocation(string location)
        {
            var restaurants = new List<Restaurant>();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.Location == location)
                {
                    restaurants.Add(restaurant);
                }
            }

            return restaurants;
        }
    }
}
