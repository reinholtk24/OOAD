
public class Customer {
	int type; 
	String name; 
	int maxNights;
	int maxTools; 
	int minNights; 
	int minTools; 
	boolean available;
	
	public Customer(String name){
		setName(name); 
	}
	
	public String getType(){return "";} 
	public void setType() {}
	
	public String getName(){
		return name; 
	}
	public void setName(String name){
		this.name = name; 
	}
	public int getMaxNights(){
		return maxNights; 
	}
	public void setMaxNights(int nights){
		maxNights = nights; 
	}
	public int getMinNights(){
		return minNights; 
	}
	public void setMinNights(int nights){
		minNights = nights; 
	}
	public int getMaxTools(){
		return maxTools; 
	}
	public void setMaxTools(int tools){
		maxTools = tools; 
	}
	public int getMinTools(){
		return minTools; 
	}
	public void setMinTools(int tools){
		minTools = tools; 
	}
	public boolean getStatus() {
		return available;
	}
	public void setStatus(boolean status) {
		this.available = status;
	}
	
	public String toString(){
		return String.format("Customer Name: " + name + " Type: " + getType() + " Nights: " + minNights + "-"+maxNights + " Tools: " + minTools +"-"+maxTools); 
	}
	
}
