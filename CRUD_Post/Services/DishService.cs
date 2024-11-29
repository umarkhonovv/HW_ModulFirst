using CRUD_Post.Models;

namespace CRUD_Post.Services;

public class DishService
{
    private List<Dish> dishes;

    public DishService()
    {
        dishes = new List<Dish>();
    }

    public Dish Add(Dish dish)
    {
        dish.Id = Guid.NewGuid();
        dishes.Add(dish);

        return dish;
    }

    public Dish GetById(Guid id)
    {
        foreach (var dish in dishes)
        {
            if (dish.Id == id)
            {
                return dish;
            }
        }

        return null;
    }

    public bool Delete(Guid id)
    {
        var result = GetById(id);
        if (result is null)
        {
            return false;
        }

        var index = dishes.IndexOf(result);
        dishes.RemoveAt(index);

        return true;
    }

    public bool Update(Dish dish)
    {
        var result = GetById(dish.Id);
        if (result is null)
        {
            return false;
        }
        var index = dishes.IndexOf(result);
        dishes[index] = dish;

        return true;
    }

    public List<Dish> GetAll()
    {
        return dishes;
    }

    public Dish GetMostExpensiveDishByRestaurant(Restaurant restaurant)
    {
        var expensiveDish = new Dish();
        foreach (var dish in restaurant.Dishes)
        {
            if (dish.Price > expensiveDish.Price)
            {
                expensiveDish = dish;
            }
        }

        return expensiveDish;
    }

    public List<Dish> GetAllDishesUnderPrice(double price)
    {
        var dishesUnderPrice = new List<Dish>();
        foreach (var dish in dishes)
        {
            if (dish.Price < price)
            {
                dishesUnderPrice.Add(dish);
            }
        }

        return dishesUnderPrice;
    }

    public Dish SearchDishByName(string name)
    {
        foreach (var dish in dishes)
        {
            if (dish.Name == name)
            {
                return dish;
            }
        }

        return null;
    }

    public double GetAverageDishPriceByRestaurant(Restaurant restaurant)
    {
        var averagePrice = 0.0;
        foreach (var dish in restaurant.Dishes)
        {
            averagePrice += dish.Price;
        }
        var result = averagePrice / restaurant.Dishes.Count;

        return result;
    }

    public bool AssignDishToAnotherRestaurant(Restaurant restaurant, Dish dish)
    {
        restaurant.Dishes.Add(dish);

        return true;
    }

    public Dish GetCheapestDishAcrossRestaurants(List<Restaurant> restaurants)
    {
        var cheapestDish = new Dish();
        cheapestDish.Price = double.MaxValue;
        foreach (var restaurant in restaurants)
        {
            foreach (var dish in restaurant.Dishes)
            {
                if (dish.Price < cheapestDish.Price)
                {
                    cheapestDish = dish;
                }
            }
        }

        return cheapestDish;
    }
}
