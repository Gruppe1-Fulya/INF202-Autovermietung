using System;
using System.Collections.Generic;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; set; }
    public List<string> Features { get; set; } 

    public Car()
    {
        Features = new List<string>();
    }
}

class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string LicenseNumber { get; set; }
}

class Rental
{
    public Car Car { get; set; }
    public Customer Customer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }

    public Rental(Car car, Customer customer, DateTime startDate, DateTime endDate)
    {
        Car = car;
        Customer = customer;
        StartDate = startDate;
        EndDate = endDate;
        TotalCost = CalculateTotalCost();
    }

    private decimal CalculateTotalCost()
    {
        TimeSpan duration = EndDate - StartDate;
        int totalDays = (int)duration.TotalDays;
        return totalDays * Car.DailyRate;
    }
}

class Program
{
    static List<Car> cars;
    static List<Rental> rentals;

    static void Main(string[] args)
    {
        InitializeData();

        Console.WriteLine("Mevcut arabalar:");
        PrintCars();

        Console.WriteLine();

        Customer customer = CreateCustomer();
        Car selectedCar = SelectCar();

        if (selectedCar != null)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(5);

            Rental rental = new Rental(selectedCar, customer, startDate, endDate);
            rentals.Add(rental);

            Console.WriteLine("\nKiralama tamamlandı. Detaylar:");
            Console.WriteLine($"Müşteri: {customer.Name}");
            Console.WriteLine($"Araba: {selectedCar.Brand} {selectedCar.Model}");
            Console.WriteLine($"Başlangıç Tarihi: {startDate}");
            Console.WriteLine($"Bitiş Tarihi: {endDate}");
            Console.WriteLine($"Toplam Ücret: {rental.TotalCost}");
        }

        Console.ReadLine();
    }

    static void InitializeData()
    {
        cars = new List<Car>
        {
            new Car { Brand = "Toyota", Model = "Corolla", Year = 2021, DailyRate = 100, IsAvailable = true, Features = new List<string> { "Bluetooth", "Gerçek Deri Koltuklar" } },
            new Car { Brand = "Honda", Model = "Civic", Year = 2022, DailyRate = 120, IsAvailable = true, Features = new List<string> { "Navigasyon", "Hız Sabitleyici" } },
            new Car { Brand = "Ford", Model = "Mustang", Year = 2020, DailyRate = 200, IsAvailable = true, Features = new List<string> { "Güneş Tavanı", "Spor Egzoz" } }
        };

        rentals = new List<Rental>();
    }

    static void PrintCars()
    {
        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Brand} {car.Model} - Yıl: {car.Year} - Günlük Ücret: {car.DailyRate} - Kullanılabilirlik: {(car.IsAvailable ? "Mevcut" : "Kiralık")}");
            Console.WriteLine("Özellikler: " + string.Join(", ", car.Features));
        }
    }

    static Customer CreateCustomer()
    {
        Console.WriteLine("Müşteri Bilgilerini Girin:");
        Console.Write("Adı Soyadı: ");
        string name = Console.ReadLine();

        Console.Write("Yaşı: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Sürücü Belge Numarası: ");
        string licenseNumber = Console.ReadLine();

        return new Customer { Name = name, Age = age, LicenseNumber = licenseNumber };
    }

    static Car SelectCar()
    {
        Console.WriteLine("\nKiralamak istediğiniz arabanın markasını ve modelini seçin:");

        Console.Write("Marka: ");
        string brand = Console.ReadLine();

        Console.Write("Model: ");
        string model = Console.ReadLine();

        foreach (Car car in cars)
        {
            if (car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) && car.Model.Equals(model, StringComparison.OrdinalIgnoreCase) && car.IsAvailable)
            {
                car.IsAvailable = false; // Arabayı kiraladık olarak işaretle
                return car;
            }
        }

        Console.WriteLine("Seçilen araba bulunamadı veya kiralanamaz durumda.");
        return null;
    }

    static void PrintRentals()
    {
        Console.WriteLine("Kiralama Geçmişi:");
        foreach (Rental rental in rentals)
        {
            Console.WriteLine($"Müşteri: {rental.Customer.Name}");
            Console.WriteLine($"Araba: {rental.Car.Brand} {rental.Car.Model}");
            Console.WriteLine($"Başlangıç Tarihi: {rental.StartDate}");
            Console.WriteLine($"Bitiş Tarihi: {rental.EndDate}");
            Console.WriteLine($"Toplam Ücret: {rental.TotalCost}");
            Console.WriteLine("--------------------------------");
        }
    }
}
