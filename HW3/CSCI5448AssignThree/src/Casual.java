
public class Casual extends Customer {
	
	Casual(String name)
	{ 
		super(name); 
		setMaxNights(2); 
		setMaxTools(2); 
		setMinNights(1); 
		setMinTools(1); 
	}
	
	@Override
	public void setType()
	{
		type = 1; 
	}
	
	@Override
	public String getType()
	{
		return "Casual"; 
	}
}
