import java.util.*;

public class main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub 
		
		List<Customer> customers = createTestCustomerList(); 
		print(customers); 
		
	}
	
	public static void print(List<Customer> cs)
	{
		for(Customer c : cs) {
            System.out.println(c.getName());
        }
	}
	
	public static List<Customer> createTestCustomerList()
	{
		List<Customer> test = new ArrayList<Customer>(); 
		
		Customer joe = new Casual(1,"Joe",2,2); 
		Customer gertrude = new Business(2,"Gertrude",7,3);
		Customer diezel = new Regular(3,"Diezel",5,3);
		
		test.add(joe); 
		test.add(gertrude); 
		test.add(diezel); 
		
		return test; 
	}

}
