@RestController
@RequestMapping("/api/rentals")
public class RentalController {

  @Autowired
  private RentalService rentalService;

  @PostMapping("/")
  public ResponseEntity<?> createRental(@RequestBody Rental rental) {
    try {
      Rental createdRental = rentalService.createRental(rental);
      return new ResponseEntity<>(createdRental, HttpStatus.CREATED);
    } catch (Exception e) {
      return new ResponseEntity<>(e.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR);
    }
  }

  @GetMapping("/{id}")
  public ResponseEntity<?> getRentalById(@PathVariable("id") Long id) {
    try {
      Rental rental = rentalService.getRentalById(id);
      return new ResponseEntity<>(rental, HttpStatus.OK);
    } catch (Exception e) {
      return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
    }
  }

  @GetMapping("/")
  public ResponseEntity<?> getAllRentals() {
    try {
      List<Rental> rentals = rentalService.getAllRentals();
      return new ResponseEntity<>(rentals, HttpStatus.OK);
    } catch (Exception e) {
      return new ResponseEntity<>(e.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR);
    }
  }

  @PutMapping("/{id}")
  public ResponseEntity<?> updateRental(@PathVariable("id") Long id, @RequestBody Rental rental) {
    try {
      Rental updatedRental = rentalService.updateRental(id, rental);
      return new ResponseEntity<>(updatedRental, HttpStatus.OK);
    } catch (Exception e) {
      return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
    }
  }

  @DeleteMapping("/{id}")
  public ResponseEntity<?> deleteRental(@PathVariable("id") Long id) {
    try {
      rentalService.deleteRental(id);
      return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    } catch (Exception e) {
      return new ResponseEntity<>(e.getMessage(), HttpStatus.NOT_FOUND);
    }
  }
}
