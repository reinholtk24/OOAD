
public class Business extends Customer{
	
	Business(String name){
		super(name); 
		setMaxNights(7); 
		setMaxTools(3); 
		setMinNights(7); 
		setMinTools(3); 
	}
	
	@Override
	public void setType(){
		type = 2; 
	}
	
	@Override
	public String getType(){
		return "Business"; 
	}

}
