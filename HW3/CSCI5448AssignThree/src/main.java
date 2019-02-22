import java.util.*;

public class main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub 
		test1(); 	
	}
	
	//Testing various constructors, and basic flow of the program using each type of object
	public static void test1(){
		Inventory allTools = new Inventory(); 
		Report report = new Report(); 
		
		List<Customer> customers = createTestCustomerList(); 
		
		System.out.println("Listing customers in Test List"); 
		print(customers); 
		
		//Assigning current customer
		Customer currentCustomer = customers.get(0); 
		
		// Creating test tool orders 
		Tool t1 = new Tool(3.0,"PaintTool1"); 
		Tool t2 = new Tool(10.0,"WoodWork1");
		
		List<Tool> ts = new ArrayList<Tool>(); 
		List<Tool> ts2 = new ArrayList<Tool>(); 
		
		ts.add(t1);
		ts.add(t2);
		ts2.add(t2); 
		
		//Keep track of day, this is saying today is day one that store is open
		// In the rental, day+nights will equal the return date. 
		// At the beginning of everyday before customers come in the store, we can scan all rentals for returns.
		int day = 1; 
		
		//Creating Rentals, Rental requires name, list of tools, max number of nights, and it needs to be active. 
		Rental r = new Rental(currentCustomer.getName(),ts,currentCustomer.getMaxNights(),1,true); 
		Rental r2 = new Rental(customers.get(1).getName(),ts2,customers.get(1).getMaxNights(),1,false);
		
		//Add both rental transactions to report
		report.addRental(r);
		report.addRental(r2);
		
		//Calculate total profit
		report.calculateTotalProfit(); 
		
		//The report will print out all rentals in the entire system then print total profit. 
		System.out.println(""); 
		System.out.println("Printing Report"); 
		System.out.println(report.toString()); 
		
		//Test current Rentals, this will only print active rentals. it should only show info from Rental r
		System.out.println(""); 
		System.out.println("Printing Current Rentals still active (with rent status active or true)");
		report.currentToolsRented();
		
		System.out.println(""); 
		System.out.println("Check inventory at the end of simulation, this will check the tools in the Inventory object and add them to the report"); 
		report.getToolsInStore(allTools);
	}
	
	
	/**
	 * For testing purposes only
	 * @param cs
	 */
	public static void print(List<Customer> cs){
		for(Customer c : cs) {
            System.out.println(c.toString()); 
        }
	}
	
	/**
	 * For testing purposes only 
	 * @return
	 */
	public static List<Customer> createTestCustomerList(){
		List<Customer> test = new ArrayList<Customer>(); 
		
		Customer joe = new Casual("Joe"); 
		Customer gertrude = new Business("Gertrude");
		Customer diezel = new Regular("Diezel");
		
		test.add(joe); 
		test.add(gertrude); 
		test.add(diezel); 
		
		return test; 
	}

}
