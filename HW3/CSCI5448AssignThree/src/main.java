import java.util.*;

public class main {

	public static void main(String[] args) {
		
		//Facade pattern used to hide the details of the store
		Simulator storeSim = new Simulator(); 
		
		System.out.println("Store Simulator Starting");
		
		//run simulator
		storeSim.run(); 
		
		System.out.println("Store Simulator Over.");	
	}

}
