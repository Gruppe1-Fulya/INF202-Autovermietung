document.addEventListener("DOMContentLoaded", function() {

  var carList = document.getElementById("carList");
  var cars = [
    { brand: "Toyota", model: "Corolla", year: 2021, dailyRate: 100, isAvailable: true },
    { brand: "Honda", model: "Civic", year: 2022, dailyRate: 120, isAvailable: true },
    { brand: "Ford", model: "Mustang", year: 2020, dailyRate: 200, isAvailable: true }
  ];

  for (var i = 0; i < cars.length; i++) {
    var car = cars[i];
    var carDiv = document.createElement("div");
    carDiv.innerHTML = "<h3>" + car.brand + " " + car.model + "</h3>" +
                       "<p>Yıl: " + car.year + "</p>" +
                       "<p>Günlük Ücret: " + car.dailyRate + "</p>" +
                       "<p>Kullanılabilirlik: " + (car.isAvailable ? "Mevcut" : "Kiralık") + "</p>";
    carList.appendChild(carDiv);
  }


  var rentalForm = document.getElementById("rentalForm");
  rentalForm.addEventListener("submit", function(event) {
    event.preventDefault(); // Formun otomatik gönderimini engelle

    var name = document.getElementById("name").value;
    var age = document.getElementById("age").value;
    var license = document.getElementById("license").value;
    var startDate = document.getElementById("startDate").value;
    var endDate = document.getElementById("endDate").value;

    rentalForm.reset();
  });


  var rentalHistory = document.getElementById("rentalHistory");
  var rentals = [
    { customer: "John Doe", car: "Toyota Corolla", startDate: "2023-01-01", endDate: "2023-01-05", totalCost: 500 },
    { customer: "Jane Smith", car: "Honda Civic", startDate: "2023-02-10", endDate: "2023-02-15", totalCost: 600 }
  ];

  for (var j = 0; j < rentals.length; j++) {
    var rental = rentals[j];
    var rentalDiv = document.createElement("div");
    rentalDiv.innerHTML = "<p>Müşteri: " + rental.customer + "</p>" +
                          "<p>Araba: " + rental.car + "</p>" +
                          "<p>Başlangıç Tarihi: " + rental.startDate + "</p>" +
                          "<p>Bitiş Tarihi: " + rental.endDate + "</p>" +
                          "<p>Toplam Ücret: " + rental.totalCost + "</p>";
    rentalHistory.appendChild(rentalDiv);
  }
});
