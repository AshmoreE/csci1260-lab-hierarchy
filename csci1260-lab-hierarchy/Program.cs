namespace csci1260_lab_hierarchy;

public class Program
{
    // Displays a report line from any object that implements IReportable.
    static void Show(IReportable r)
    {
        Console.WriteLine(r.ReportLine());
    }

    public static void Main()
    {
        // Create the shop.
        Shop shop = new Shop("River City Supply");

        Console.Write("Opening catalog: ");
        Show(shop);

        Console.WriteLine();
        Console.WriteLine("Loading five records...");

        // Program creates the records and gives them to Shop.
        // This demonstrates aggregation.
        PerishableGood honey = new PerishableGood(
            "HON01",
            "Wildflower honey",
            8.00m,
            12,
            1.5,
            2
        );

        DurableGood kettle = new DurableGood(
            "KTL11",
            "Cast iron kettle",
            24.00m,
            5,
            4.0,
            24
        );

        PerishableGood cheddar = new PerishableGood(
            "CHZ07",
            "Farm cheddar wedge",
            3.50m,
            40,
            0.5,
            9
        );

        ServiceItem sharpening = new ServiceItem(
            "SRV20",
            "Knife sharpening",
            60.00m,
            2,
            2.5
        );

        ServiceItem wrapping = new ServiceItem(
            "SRV21",
            "Gift wrapping",
            15.00m,
            3,
            1.0
        );

        int recordsAccepted = 0;

        if (shop.Add(honey))
        {
            recordsAccepted++;
        }

        if (shop.Add(kettle))
        {
            recordsAccepted++;
        }

        if (shop.Add(cheddar))
        {
            recordsAccepted++;
        }

        if (shop.Add(sharpening))
        {
            recordsAccepted++;
        }

        if (shop.Add(wrapping))
        {
            recordsAccepted++;
        }

        // Attempt to add a duplicate SKU.
        PerishableGood duplicateHoney = new PerishableGood(
            "HON01",
            "Duplicate honey",
            8.00m,
            1,
            1.0,
            5
        );

        if (!shop.Add(duplicateHoney))
        {
            Console.WriteLine(" REJECTED: duplicate SKU HON01");
        }


        // --------------------------------------------------
        // Record inventory movements.
        // --------------------------------------------------

        Console.WriteLine();
        Console.WriteLine("Recording four movements...");

        int movementsAccepted = 0;

        StockItem item = shop.Find("HON01");

        if (item != null)
        {
            if (item.Receive(6))
            {
                movementsAccepted++;
            }
        }

        item = shop.Find("KTL11");

        if (item != null)
        {
            if (item.Release(2))
            {
                movementsAccepted++;
            }
        }

        item = shop.Find("KTL11");

        if (item != null)
        {
            if (!item.Release(99))
            {
                Console.WriteLine(
                    " REJECTED: release of 99 from KTL11"
                );
            }
            else
            {
                movementsAccepted++;
            }
        }

        item = shop.Find("CHZ07");

        if (item != null)
        {
            if (!item.Receive(-5))
            {
                Console.WriteLine(
                    " REJECTED: receive of -5 into CHZ07"
                );
            }
            else
            {
                movementsAccepted++;
            }
        }


        // --------------------------------------------------
        // Display accepted totals.
        // --------------------------------------------------

        Console.WriteLine();

        Console.WriteLine(
            $"Records accepted: {recordsAccepted}"
        );

        Console.WriteLine(
            $"Movements accepted: {movementsAccepted}"
        );

        Console.WriteLine();


        // --------------------------------------------------
        // Display the third record.
        // ToString() ultimately calls Describe().
        // --------------------------------------------------

        Console.WriteLine($"Top record: {cheddar}");

        Console.WriteLine();


        // --------------------------------------------------
        // Sort and print the inventory report.
        // --------------------------------------------------

        shop.SortByValue();
        shop.PrintReport();


        // --------------------------------------------------
        // Contract check.
        // --------------------------------------------------

        Console.WriteLine();

        Console.WriteLine("Contract check");

        Console.WriteLine(
            $"Records signing IDiscountable: {shop.SignedCount()}"
        );

        Console.WriteLine(
            $"Records on sale right now: {shop.OnSaleCount()}"
        );

        Console.WriteLine(
            $"Difference between the two totals: " +
            $"{shop.TotalValue() - shop.SaleValue():C}"
        );


        // --------------------------------------------------
        // Composition check.
        // --------------------------------------------------

        Console.WriteLine();

        Console.WriteLine("Composition check");

        StockItem honeyCheck = shop.Find("HON01");

        if (honeyCheck != null)
        {
            Console.WriteLine(
                $"Movements recorded by HON01: {honeyCheck.MoveCount}"
            );

            if (honeyCheck.MoveCount > 0)
            {
                Console.WriteLine(honeyCheck.MovementLines());
            }
        }

        StockItem kettleCheck = shop.Find("KTL11");

        if (kettleCheck != null)
        {
            Console.WriteLine(
                $"Movements recorded by KTL11: {kettleCheck.MoveCount}"
            );

            if (kettleCheck.MoveCount > 0)
            {
                Console.WriteLine(kettleCheck.MovementLines());
            }
        }

        StockItem cheddarCheck = shop.Find("CHZ07");

        if (cheddarCheck != null)
        {
            Console.WriteLine(
                $"Movements recorded by CHZ07: {cheddarCheck.MoveCount}"
            );

            if (cheddarCheck.MoveCount > 0)
            {
                Console.WriteLine(cheddarCheck.MovementLines());
            }
        }


        // StockItem cannot be instantiated because it is abstract.
        // StockItem test = new StockItem("TEST", "Test", 1.00m, 1);
        // CS0144: Cannot create an instance of the abstract type or interface.
    }
}