# CSCI 1260 Hierarchy Lab

Name: Ethan Ashmore
Section: 002
Unfinished: Nothing im finished

## Track A: Shop

This project creates an inventory system for River City Supply using inheritance, abstract classes, interfaces, aggregation, composition, and polymorphism. The inventory can contain perishable goods, durable goods, and service items while allowing the Shop class to manage them through the common StockItem base class.

## How to run: 
Open in Visual Studio and run the program. The Consol will display the expected output for River City Supply.

## Design Questions

### Question 1

PhysicalGood is abstract because it represents a shared category for physical inventory items rather than a complete type of item that should be created on its own. It contains real code because PerishableGood and DurableGood both need the same weight information, ShippingCost() calculation, and part of the Describe() behavior.

If PhysicalGood were concrete, the program would allow someone to create a generic physical good that does not represent one of the actual inventory categories. It would also need its own implementations of methods such as Category() and HandlingFee(). Keeping it abstract makes sure that an actual object must be a more specific type, such as PerishableGood or DurableGood.

### Question 2 

The hollow diamond between Shop and StockItem represents aggregation. Program creates the StockItem objects and then passes them into Shop using Add(). The items can exist independently of the Shop, so deleting the Shop would not automatically mean that the StockItem objects have to stop existing.

The filled diamond between StockItem and StockMovement represents composition. A StockItem creates its own StockMovement objects inside Receive() and Release(). Those movements belong to that specific StockItem and are stored in its history. They are not created or managed separately by Program.

If Shop.Add() instead took primitive values and created the StockItem objects itself, the relationship would move toward composition because Shop would become responsible for creating the records it contains. For this assignment, I think that would be a mistake because it would give Shop more responsibility and make it more dependent on the different StockItem types. The current design lets Program create the correct type and lets Shop work with all of them through StockItem.

### Question 3

I would create a new Rental class that inherits from PhysicalGood because rentals have bulk and would need the weight and shipping behavior that PhysicalGood already provides. I would also have Rental implement IDiscountable because rentals can go on sale. The Rental class could contain its own field and property for the required deposit along with its implementations of Category(), HandlingFee(), SalePrice(), IsOnSale, and Describe().

I would create Rental.cs and update Program.cs so that Program creates a Rental object and adds it to the Shop. Shop.cs should not need to change because Shop already stores objects as StockItem and checks for IDiscountable when it needs sale information. This means a Rental can work with the existing system through inheritance and the interface.

If IsOnSale were placed directly on StockItem, every StockItem would be forced to have sale behavior even when that behavior does not make sense. DurableGood is an example because it does not implement IDiscountable. Keeping IsOnSale in IDiscountable allows only the classes that actually support discounts, such as PerishableGood, ServiceItem, and the new Rental class, to provide that behavior.